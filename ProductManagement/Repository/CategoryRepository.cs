using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

using ProductManagement.Models;


namespace ProductManagement.Repository
{
    public class CategoryRepository
    {
        public List<Category> GetCategories()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            List<Category> categories = new List<Category>();

            // Use ADO.NET to retrieve categories from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetCategories", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category
                    {
                        CatId = Convert.ToInt32(reader["CatID"]),
                        CatName = reader["CatName"].ToString(),
                        CatImage = reader["CatImage"].ToString(),
                        CatDesc = reader["CatDesc"].ToString(),
                    };
                    categories.Add(category);
                }

                return categories;
            }
        }

        public List<ProductsCategory> GetProductCategoriesById(int catId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            List<ProductsCategory> productsCategories = new List<ProductsCategory>();

            // Use ADO.NET to retrieve categories from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetProductsByCategory", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CatID", catId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductsCategory category = new ProductsCategory
                    {
                        CatID = Convert.ToInt32(reader["CatID"]),
                        ProdId = Convert.ToInt32(reader["ProdId"]),
                        Price = Convert.ToString(reader["Price"]),
                        ProdDesc = Convert.ToString(reader["ProdDesc"]),
                        ProdImg = Convert.ToString(reader["ProdImg"]),
                        ProdName = Convert.ToString(reader["ProdName"])
                    };
                    productsCategories.Add(category);
                }

                return productsCategories;
            }
        }
    }
}