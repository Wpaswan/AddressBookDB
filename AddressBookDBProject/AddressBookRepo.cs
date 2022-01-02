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
                    { //use LINQ to query the list for the first person with the same first name as the first name the user entered.
                      //used lambda operator

                        AddressBookModel person1 = People.FirstOrDefault(x => x.firstname==data.firstname);
                        AddressBookModel person2 = People.FirstOrDefault(x => x.lastname==data.lastname);
                        //Duplicate Check is done on Person Name while adding person to Address Book
                        if (person1!=null && person2!=null)
                        {
                            Console.WriteLine("Sorry this contact exist");
                        }
                        else
                        {
                            People.Add(data);
                            PeopleDictionary[AddressBookName]=People;
                        }
                        return data;
                    }
                    if (PeopleDictionary.Count == 0)
                    {
                        Console.WriteLine("Your address book is empty. Press any key to continue.");
                        Console.ReadKey();
                        
                    }
                    Console.WriteLine("Here are the current people in your address book:\n");
                    foreach(KeyValuePair<string, List<AddressBookModel>> valuePair in PeopleDictionary)
                    {
                        Console.WriteLine("Address book name:"+valuePair.Key);
                        foreach (AddressBookModel person in valuePair.Value)
                        {
                            Console.WriteLine("Id="+person.id);
                            Console.WriteLine("First Name: " + person.firstname);
                            Console.WriteLine("Last Name: " + person.lastname);
                            Console.WriteLine("Phone Number: " + person.phonenumber);
                            Console.WriteLine("Address: " + person.address);
                            Console.WriteLine("city: " + person.city);
                            Console.WriteLine("State : " + person.state);
                            Console.WriteLine("Zip:"+person.zip);
                            
                            Console.WriteLine("-------------------------------------------");
                        }
                    }

                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
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
        public void sortByCityStateOrZip()
        {
            Console.WriteLine("Enter 1 for city 2 for state and 3 for zip to sort the details");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    foreach (var addressBook in PeopleDictionary)
                    {
                        Console.WriteLine("Address book name:"+addressBook.Key);

                        foreach (var person in
                            addressBook.Value.OrderBy(x => x.city))
                        {
                            Console.WriteLine("Id="+person.id);
                            Console.WriteLine("First Name: " + person.firstname);
                            Console.WriteLine("Last Name: " + person.lastname);
                            Console.WriteLine("Phone Number: " + person.phonenumber);
                            Console.WriteLine("Address: " + person.address);
                            Console.WriteLine("city: " + person.city);
                            Console.WriteLine("State : " + person.state);
                            Console.WriteLine("Zip:"+person.zip);

                            Console.WriteLine("-------------------------------------------");
                        }
                    }
                    break;
                case 2:
                    foreach (var addressBook in PeopleDictionary)
                    {
                        Console.WriteLine("Address book name:"+addressBook.Key);

                        foreach (var person in
                            addressBook.Value.OrderBy(x => x.state))
                        {
                            Console.WriteLine("Id="+person.id);
                            Console.WriteLine("First Name: " + person.firstname);
                            Console.WriteLine("Last Name: " + person.lastname);
                            Console.WriteLine("Phone Number: " + person.phonenumber);
                            Console.WriteLine("Address: " + person.address);
                            Console.WriteLine("city: " + person.city);
                            Console.WriteLine("State : " + person.state);
                            Console.WriteLine("Zip:"+person.zip);

                            Console.WriteLine("-------------------------------------------");
                        }
                    }
                    break;
                case 3:
                    foreach (var addressBook in PeopleDictionary)
                    {
                        Console.WriteLine("Address book name:"+addressBook.Key);

                        foreach (var person in
                            addressBook.Value.OrderBy(x => x.zip))
                        {
                            Console.WriteLine("Id="+person.id);
                            Console.WriteLine("First Name: " + person.firstname);
                            Console.WriteLine("Last Name: " + person.lastname);
                            Console.WriteLine("Phone Number: " + person.phonenumber);
                            Console.WriteLine("Address: " + person.address);
                            Console.WriteLine("city: " + person.city);
                            Console.WriteLine("State : " + person.state);
                            Console.WriteLine("Zip:"+person.zip);

                            Console.WriteLine("-------------------------------------------");
                        }
                    }
                    break;
            }
        }
        public void sortByFirstName()
        {
            foreach (var addressBook in PeopleDictionary)
            {
                Console.WriteLine("Address book name:"+addressBook.Key);

                foreach (var person in
                    addressBook.Value.OrderBy(x => x.firstname))
                {
                    Console.WriteLine("Id="+person.id);
                    Console.WriteLine("First Name: " + person.firstname);
                    Console.WriteLine("Last Name: " + person.lastname);
                    Console.WriteLine("Phone Number: " + person.phonenumber);
                    Console.WriteLine("Address: " + person.address);
                    Console.WriteLine("city: " + person.city);
                    Console.WriteLine("State : " + person.state);
                    Console.WriteLine("Zip:"+person.zip);

                    Console.WriteLine("-------------------------------------------");
                }
            }

        }
        public void FindPersonInCityOrState()
        {
            Console.WriteLine("Enter  1. for city 2. state to find for particular person");
            int ch = Convert.ToInt32(Console.ReadLine());



            switch (ch)
            {
                case 1:
                    Console.WriteLine("Choose Type city else or state to find perticular person");
                    string city1 = Console.ReadLine();

                    //creating list of person according to city
                    List<AddressBookModel> cityWisePeople = new List<AddressBookModel>();
                    Dictionary<string, List<AddressBookModel>> cityWisePeopleDictionary = new Dictionary<string, List<AddressBookModel>>();


                    foreach (KeyValuePair<string, List<AddressBookModel>> valuePair in PeopleDictionary)
                    { //for state do the same thing for state
                        AddressBookModel person1 = valuePair.Value.Find(x => x.city.ToLower()==city1.ToLower());
                        if (person1!=null)
                        {
                            cityWisePeople.Add(person1);

                        }

                    }
                    cityWisePeopleDictionary[city1]=cityWisePeople;
                    Console.WriteLine($"People in {city1}: ");
                    foreach (var city in cityWisePeopleDictionary.Keys)
                    {
                        if (city.ToLower()==city1.ToLower())
                        {
                            foreach (var person in cityWisePeopleDictionary[city])
                            {
                                if (person!=null)
                                {
                                    Console.WriteLine("Id="+person.id);
                                    Console.WriteLine("First Name: " + person.firstname);
                                    Console.WriteLine("Last Name: " + person.lastname);
                                    Console.WriteLine("Phone Number: " + person.phonenumber);
                                    Console.WriteLine("Address: " + person.address);
                                    Console.WriteLine("city: " + person.city);
                                    Console.WriteLine("State : " + person.state);
                                    Console.WriteLine("Zip:"+person.zip);

                                    Console.WriteLine("-------------------------------------------");
                                }
                            }
                        }
                    }
                    int countPeople = cityWisePeopleDictionary.Count;
                    Console.WriteLine("Total number of people in perticular city:"+countPeople);

                    break;
                case 2:
                    Console.WriteLine("Enter state to find perticular person");
                    string SearchAccordingstate = Console.ReadLine();

                    //creating list of person according to city
                    List<AddressBookModel> stateWisePeople = new List<AddressBookModel>();
                    Dictionary<string, List<AddressBookModel>> stateWisePeopleDictionary = new Dictionary<string, List<AddressBookModel>>();


                    foreach (KeyValuePair<string, List<AddressBookModel>> valuePair in PeopleDictionary)
                    { //Using lambda => here
                        AddressBookModel person1 = valuePair.Value.Find(x => x.state.ToLower()==SearchAccordingstate.ToLower());
                        if (person1!=null)
                        {
                            stateWisePeople.Add(person1);

                        }

                    }
                    stateWisePeopleDictionary[SearchAccordingstate]=stateWisePeople;
                    Console.WriteLine($"People in {SearchAccordingstate}: ");
                    foreach (var state in stateWisePeopleDictionary.Keys)
                    {
                        if (state.ToLower()==SearchAccordingstate.ToUpper())
                        {
                            foreach (var person in stateWisePeopleDictionary[state])
                            {
                                if (person!=null)
                                {

                                    Console.WriteLine("Id="+person.id);
                                    Console.WriteLine("First Name: " + person.firstname);
                                    Console.WriteLine("Last Name: " + person.lastname);
                                    Console.WriteLine("Phone Number: " + person.phonenumber);
                                    Console.WriteLine("Address: " + person.address);
                                    Console.WriteLine("city: " + person.city);
                                    Console.WriteLine("State : " + person.state);
                                    Console.WriteLine("Zip:"+person.zip);

                                    Console.WriteLine("-------------------------------------------");
                                }
                            }
                        }

                    }
                    int countPeople1 = stateWisePeopleDictionary.Count;
                    Console.WriteLine("Total number of people in perticular city:"+countPeople1);
                    break;
                default:
                    Console.WriteLine("Wrong choice!!");
                    break;

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
