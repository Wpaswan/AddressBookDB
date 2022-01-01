using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDBProject
{
    public class AddressBookRepo
    {
       
       public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                         Initial Catalog=AddressBookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //To Add details    
        public AddressBookModel AddData(AddressBookModel data)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand com = new SqlCommand("AddAddressBook1", connection);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@firstname", data.firstname);
                    com.Parameters.AddWithValue("@lastname", data.lastname);
                    com.Parameters.AddWithValue("@address", data.address);
                    com.Parameters.AddWithValue("@city", data.city);
                    com.Parameters.AddWithValue("@state", data.state);
                    com.Parameters.AddWithValue("@zip", data.zip);
                    com.Parameters.AddWithValue("@phonenumber", data.phonenumber);
                    com.Parameters.AddWithValue("@email", data.email);

                    connection.Open();
                    int i = com.ExecuteNonQuery();

                    var result = com.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {

                        return data;
                    }
                    return default;



                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool UpdateAddressBookDetail(int id, string firstname)
        {
            try
            {
                Console.WriteLine("Enter Last Name");
                string lastName=Console.ReadLine();
                Console.WriteLine("Enter Address");
                string Address = Console.ReadLine();
                Console.WriteLine("Enter city");
                string city = Console.ReadLine();
                Console.WriteLine("Enter state");
                string state = Console.ReadLine();
                Console.WriteLine("Enter zip");
                int zip = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter phone number");
                string phonenumber = Console.ReadLine();
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand com = new SqlCommand("UpdateAddressBook4", connection);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@firstname", firstname);
                com.Parameters.AddWithValue("@lastname", lastName);
                com.Parameters.AddWithValue("@address", Address);
                com.Parameters.AddWithValue("@city", city);
                com.Parameters.AddWithValue("@state", state);
                com.Parameters.AddWithValue("@zip", zip);
                com.Parameters.AddWithValue("@phonenumber", phonenumber);
                com.Parameters.AddWithValue("@email", email);
                connection.Open();
                int i = com.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //To Delete Person details    
        public bool DeletePersonDetails(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand com = new SqlCommand("DeleteAddressBook", connection);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                connection.Open();
                int i = com.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
