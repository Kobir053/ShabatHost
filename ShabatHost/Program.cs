using Microsoft.Extensions.Configuration;

namespace ShabatHost
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var config = new ConfigurationBuilder()
                        .AddUserSecrets<Program>()
                        .Build();
            string? connectionString = config["ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Cannot read conn striong from secrets");
            DBContext dbCtx = new DBContext(connectionString);
            SeedService service = new SeedService(dbCtx);
            service.EnsureTables();


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormHandler formHandler = new FormHandler(dbCtx);
            formHandler.Show("Form1", dbCtx);
            Application.Run();
        }
    }
}