using System.Data;
using System.Data.SqlClient;

namespace BlazorNetworkH1.Data
{
    public class SQL
    {
        SqlConnection sqlConnection = new("Data Source=.;Initial Catalog=BreakfastH1;Integrated Security=True;");

        public bool CreateFood(Food f)
        {
            using (sqlConnection)
            {
                SqlCommand cmd = new("INSERT INTO [Food] VALUES (@item, @amount, @price)", sqlConnection);
                cmd.Parameters.Add("@item", SqlDbType.NVarChar).Value = f.Item;
                cmd.Parameters.Add("@amount", SqlDbType.Int).Value = f.Amount;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = f.Price;
                sqlConnection.Open();
                bool isSuccess = cmd.ExecuteNonQuery() == 1 ? true : false;
                sqlConnection.Close();
                return isSuccess;
            }
        }
        public List<Food> GetFood()
        {
            List<Food> foodList = new();
            SqlCommand cmd = new SqlCommand("Select * from [Food]", sqlConnection);
            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Food food = new()
                    {
                        Id = reader.GetInt32(0),
                        Item = reader.GetString(1),
                        Amount = reader.GetInt32(2),
                        Price = (Double)reader.GetDecimal(3)
                    };
                    foodList.Add(food);
                }
            }
            sqlConnection.Close();

            return foodList;
        }

        public bool DeleteFood(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [Food] WHERE Id = @Id", sqlConnection);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            sqlConnection.Open();
            bool isSuccess = cmd.ExecuteNonQuery() == 1 ? true : false;
            sqlConnection.Close();
            return isSuccess;
        }
    }
}
