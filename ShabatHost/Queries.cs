using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShabatHost
{
    internal class Queries
    {
        private DBContext _dbContext;

        public Queries(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public bool InsertCategory(string category)
        {
            string query = @"INSERT INTO Categories (CategoryName) Values (@category);";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@category", SqlDbType.VarChar) {Value = category},
            };
            int rowsAffected = _dbContext.ExecuteNonQuery(query, sqlParameters.ToArray());
            return rowsAffected > 0;
        }

        public bool InsertGuest(string name)
        {
            string query = @"INSERT INTO Guests (GuestName) Values (@newGuest);";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@newGuest", SqlDbType.VarChar) {Value = name},
            };
            int rowsAffected = _dbContext.ExecuteNonQuery(query, sqlParameters.ToArray());
            return rowsAffected > 0;
        }

        public bool InsertFood(string name, int guestID, int categoryID)
        {
            string query = @"insert into Food (FoodName, GuestID, CategoryID)
                            values (@foodName, @guestID, @categoryID);";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@foodName", SqlDbType.VarChar) {Value = name},
                new SqlParameter("@guestID", SqlDbType.Int) {Value = guestID},
                new SqlParameter("@categoryID", SqlDbType.Int) {Value = categoryID},

            };
            int rowsAffected = _dbContext.ExecuteNonQuery(query, sqlParameters.ToArray());
            return rowsAffected > 0;
        }

        public DataTable GetCategories()
        {
            string query = @"SELECT CategoryName FROM Categories;";
            DataTable res = _dbContext.MakeQuery(query, null!);
            return res;
        }

        public DataTable GetGuests()
        {
            string query = @"SELECT GuestName FROM Guests;";
            DataTable res = _dbContext.MakeQuery(query, null!);
            return res;
        }

        public DataTable GetFoodName(int userID, int categoryID)
        {
            string query = @"SELECT FoodName FROM Food where GuestID = @userID AND CategoryID = @categoryID;";
            SqlParameter[] parameters = { new SqlParameter("@categoryID", categoryID),
                                          new SqlParameter("@userID", userID) };
            DataTable res = _dbContext.MakeQuery(query, parameters);
            return res;
        }

        public DataTable GetOtherGuestsFoodName(int userID, int categoryID)
        {
            string query = @"SELECT f.FoodName AS FoodName, g.GuestName AS GuestName
                            FROM Food f INNER JOIN Guests g ON g.ID = f.GuestID
                            where GuestID != @userID AND CategoryID = @categoryID;";
            SqlParameter[] parameters = { new SqlParameter("@categoryID", categoryID),
                                          new SqlParameter("@userID", userID) };
            DataTable res = _dbContext.MakeQuery(query, parameters);
            return res;
        }

        // delete a category
        public bool Delete(int categoryId)
        {
            string query = "DELETE FROM Categories WHERE ID = @CategoryID";
            SqlParameter[] parameters = { new SqlParameter("@CategoryID", categoryId) };

            int rowsAffected = _dbContext.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public bool DeleteFood(string foodName, int guestID, int categoryID)
        {
            string query = "DELETE FROM Food WHERE FoodName = @foodName AND GuestID = @guestID AND CategoryID = @categoryID;";
            SqlParameter[] parameters = { new SqlParameter("@foodName", foodName),
                                        new SqlParameter("@guestID", guestID), new SqlParameter("@categoryID", categoryID)};

            int rowsAffected = _dbContext.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        public int FindIDByCategoryName(string categoryName)
        {
            string query = "SELECT ID FROM Categories WHERE CategoryName = @categoryName";
            SqlParameter[] parameters = { new SqlParameter("@categoryName", categoryName) };
            int res = _dbContext.ExecScalar(query, parameters);
            return res;
        }

        public int FindIDByGuestName(string guestName)
        {
            string query = "SELECT ID FROM Guests WHERE GuestName = @guestName";
            SqlParameter[] parameters = { new SqlParameter("@guestName", guestName) };
            int res = _dbContext.ExecScalar(query, parameters);
            return res;
        }

    }
}
