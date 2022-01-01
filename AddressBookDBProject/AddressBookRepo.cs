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
        public void editContacts(AddressBookModel model)
        {
            try
            {
                SqlConnection connection=new SqlConnection(connectionString);
                
                using(connection)
                {
                    SqlCommand com = new SqlCommand("AddAddressBook1", connection);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    Console.WriteLine("Enter first name");
                    string editFirstName=Console.ReadLine();
                    Console.WriteLine("Enter  name");
                    string firstName=Console.ReadLine();

                    connection.Open();

                    string query = @"update  AddressBook set firstName="+editFirstName+"  where  firstName="+firstName+""; 
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                   
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
