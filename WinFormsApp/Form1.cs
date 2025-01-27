using Newtonsoft.Json;
using System.Windows.Forms;

namespace WinFormsApp
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fetch all database info
                    var response = await client.GetAsync("http://localhost:5015/api/DatabaseInfo/"+ Settings.dbName);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var databaseInfos = JsonConvert.DeserializeObject<List<DataBaseInfo>>(content);

                    // Bind the data to the DataGridView
                    dbDataGrid.RowHeadersVisible = false;
                    dbDataGrid.DataSource = databaseInfos;
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Request error: {ex.Message}");
                }
            }
        }
     

        private async void dbDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get "Name" from clicked row
                var tableName = dbDataGrid.Rows[e.RowIndex].Cells["Name"].Value;

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Fetch all database info
                        var response = await client.GetAsync("http://localhost:5015/api/DatabaseInfo/"+ Settings.dbName + "/columns/" + tableName);
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        var databaseInfos = JsonConvert.DeserializeObject<List<ColumnInfo>>(content);

                        // Bind the data to the DataGridView
                        columnGridView.DataSource = databaseInfos;
                        columnGridView.RowHeadersVisible = false;
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Request error: {ex.Message}");
                    }
                }
            }
        }
    }

}

       
    

