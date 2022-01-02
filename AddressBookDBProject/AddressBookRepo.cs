using System;
using System.Collections.Generic;
using System.Data;
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
        public static List<AddressBookModel> People = new List<AddressBookModel>();

        public static Dictionary<string, List<AddressBookModel>> PeopleDictionary = new Dictionary<string, List<AddressBookModel>>();
        public AddressBookModel AddData(AddressBookModel data)
        {
            Console.WriteLine("Enter Address Book Name");
            string AddressBookName=Console.ReadLine();
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
                        People.Add(data);
                        PeopleDictionary[AddressBookName]=People;

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
        //To Get AddressBook Table data 
        public bool GetAllContact()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                //   SqlConnection connection = new SqlConnection(connectionString);
                AddressBookModel addressBookmodel = new AddressBookModel();
                using (connection)
                {
                    string query = @"Select * from AddressBook";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressBookmodel.firstname = dr.GetString(0);
                            addressBookmodel.lastname = dr.GetString(1);
                            addressBookmodel.address = dr.GetString(2);
                            addressBookmodel.city = dr.GetString(3);
                            addressBookmodel.state = dr.GetString(4);
                            addressBookmodel.zip =dr.GetInt32(5);
                            addressBookmodel.phonenumber = dr.GetString(6);
                            addressBookmodel.email = dr.GetString(7);
                            addressBookmodel.id = dr.GetInt32(8);
                            Console.WriteLine(addressBookmodel.id+" "+addressBookmodel.firstname+" "+addressBookmodel.lastname+" "+" "+addressBookmodel.address+" "+addressBookmodel.city+" "+addressBookmodel.state+" "+addressBookmodel.phonenumber+" "+addressBookmodel.zip+" "+addressBookmodel.email);
                           Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
