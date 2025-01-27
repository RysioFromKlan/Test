using Microsoft.AspNetCore.Mvc;
using RestJsonServer.Logic;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;


[ApiController]
[Route("api/[controller]")]
public class DatabaseInfoController : ControllerBase
{

    private static DbType GetDbType(string value)
    {
        if (value == "table")
            return DbType.TABLE;
        if (value == "view")
            return DbType.VIEW;
        else
            throw new ArgumentException("Wrong DbType in GetDbType:" + value);
    }


    [HttpGet]
    [HttpGet(template: "{dbName}", Name = "dbName")]
    public IActionResult Get(string dbName)
    {
        dbName = Helpers.CleanDbNameForUsage(dbName);
        string connectionString = "Data Source="+dbName+".db;Version=3;";
        List<DataBaseInfo> databaseInfos = new List<DataBaseInfo>();

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM sqlite_master WHERE type='table' or type='view' ;";
            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Type: {reader["type"]}, Name: {reader["Name"]}");

                        var rootPageOrd = reader.GetOrdinal("rootpage");
                        databaseInfos.Add(new DataBaseInfo
                        {
                            Name = reader["Name"].ToString(),
                            RootPage = reader.GetInt32(rootPageOrd),
                            Type = GetDbType(reader["type"].ToString())
                        });
                    }

                }
                connection.Close();

            }
            return Ok(databaseInfos);
        }
    }



    [HttpGet(template: "{dbName}/Columns/{c}", Name = "Columns")]
    public IActionResult Get(string dbName,string c)
    {
        dbName = Helpers.CleanDbNameForUsage(dbName);
        string connectionString = "Data Source=" + dbName + ".db;Version=3;";
        List<ColumnInfo> columnInfos = new List<ColumnInfo>();

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM pragma_table_info(@c)";
            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@c", c);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine($"Type: {reader["type"]}, Name: {reader["Name"]}");
                        columnInfos.Add(new ColumnInfo
                        {
                            Name = reader["name"].ToString(),
                            Type = reader["type"].ToString()
                        });
                    }
                }
                connection.Close();

            }
            return Ok(columnInfos);
        }
    }

}