public enum DbType
{
    VIEW,
    TABLE
}

public class DataBaseInfo
{
    public string Name { get; set; }
    public DbType Type { get; set; }
    public int RootPage { get; set; }
}

public class ColumnInfo
{
    public string Name { get; set; }
    public string Type { get; set; }
}