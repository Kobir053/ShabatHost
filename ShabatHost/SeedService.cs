using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatHost
{
    internal class SeedService
    {
        private DBContext _dbContext;

        // constructor
        public SeedService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // makes shure there is a tables in DB - if not it creates them
        public void EnsureTables()
        {
            string sqlStatements = @"USE Shabat;

                                    DECLARE @tablesCreated INT = 0;

                                    BEGIN TRANSACTION;

                                    BEGIN TRY

                                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Guests' AND type = 'U')
                                    BEGIN
                                        CREATE TABLE [dbo].[Guests] (
                                            [ID] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
                                            [GuestName] VARCHAR (20) UNIQUE NULL,
                                        );
                                    END

                                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categories' AND type = 'U')
                                    BEGIN
                                        CREATE TABLE [dbo].[Categories] (
                                            [ID] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
                                            [CategoryName] VARCHAR(20) UNIQUE NULL,
                                        );
                                    END

                                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Food' AND type = 'U')
                                    BEGIN
                                        CREATE TABLE [dbo].[Food] (
                                            [ID] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
                                            [FoodName] VARCHAR (15) NULL,
                                            [GuestID] INT FOREIGN KEY REFERENCES Guests (ID),
                                            [CategoryID] INT FOREIGN KEY REFERENCES Categories (ID),
                                            constraint AK_nonRepetation unique(CategoryID, GuestID, FoodName)
                                        );
                                    END

                                    SET @tablesCreated = 1;

                                    COMMIT TRANSACTION;

                                    END TRY

                                    BEGIN CATCH

                                        ROLLBACK TRANSACTION;
                                        SET @tablesCreated = 0;

                                    END CATCH

                                    SELECT @tablesCreated AS isCreated;";
            _dbContext.ExecuteNonQuery(sqlStatements, null!);
        }
    }
}
