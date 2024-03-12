using Microsoft.Data.SqlClient;
using System.Data;

ConfigureConsole();

#region Set up the connection string builder
SqlConnectionStringBuilder builder = new()
{
    InitialCatalog = "Northwind",
    MultipleActiveResultSets = true,
    TrustServerCertificate = true,
    IntegratedSecurity = true,
    ConnectTimeout = 10, // Default is 30 sec.
    DataSource = "HACKDAMN"
};

#endregion

#region Create and open the connection
SqlConnection conneciton = new(builder.ConnectionString);
WriteLine(conneciton.ConnectionString);
WriteLine();
conneciton.StateChange += Connection_StateChange;
conneciton.InfoMessage += Connection_InfoMessage;

try
{
    WriteLine("Opening connection. Please wait up to {0} seconds...", builder.ConnectTimeout);
    WriteLine();
    conneciton.Open();
    WriteLine($"SQL Server version: {conneciton.ServerVersion}");
}
catch (SqlException ex)
{

    WriteLineInColor($"SQL exception: {ex.Message}", ConsoleColor.Red);
    return;
}
#endregion

conneciton.Close();