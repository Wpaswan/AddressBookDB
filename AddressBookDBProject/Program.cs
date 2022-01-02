using AddressBookDBProject;
AddressBookModel addressBookmodel = new AddressBookModel();
AddressBookRepo repo = new AddressBookRepo();
Console.WriteLine("\t-----Welcome To Addressbook Management System------");
Console.WriteLine("\t-----1. To add                               ------");
Console.WriteLine("\t-----2. To Edit                              ------");
Console.WriteLine("\t-----3. To Delete                            ------");
Console.WriteLine("\t-----4. To Veiw                              ------");
Console.WriteLine("\t-----5. To Veiw person by city or state      -----");
Console.WriteLine("\t-----6. Sort by First name                   -----");
int choice=Convert.ToInt32(Console.ReadLine());
switch (choice) {
    case 1:
        Console.WriteLine("Enter FirstName");
        addressBookmodel.firstname=Console.ReadLine();
        Console.WriteLine("Enter LastName");
        addressBookmodel.lastname=Console.ReadLine();
        Console.WriteLine("Enter Address:");
        addressBookmodel.address=Console.ReadLine();
        Console.WriteLine("Enter City");
        addressBookmodel.city=Console.ReadLine();
        Console.WriteLine("Enter State:");
        addressBookmodel.state=Console.ReadLine();
        Console.WriteLine("Enter Zip:");
        addressBookmodel.zip=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter phone number");
        addressBookmodel.phonenumber=Console.ReadLine();
        Console.WriteLine("Enter Email");
        addressBookmodel.email=Console.ReadLine();

        var result = repo.AddData(addressBookmodel);
        if (result != null)
        {
            Console.WriteLine("Successfully Added");
        }
        else
        {
            Console.WriteLine("Not Added");
        }
        break;
        case 2:
Console.WriteLine("Enter id of person whoes data you want to update");
int personid = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter new name");
string newname = Console.ReadLine();
bool res = repo.UpdateAddressBookDetail(personid, newname);
if (res != null)
{
    Console.WriteLine("Successfully updated");
}
else
{
    Console.WriteLine("Not updated");
}
break ;
        case 3:
        Console.WriteLine("Enter id to Delete Data");
        int num = Convert.ToInt32(Console.ReadLine());
        var resultDelete=repo.DeletePersonDetails(num);
        if (resultDelete != null)
            Console.WriteLine("Record deleted");
        else
            Console.WriteLine("Not deleted");
        break;
    case 4:
        repo.GetAllContact();
        break;
    case 5:
        repo.FindPersonInCityOrState();
        break;
    case 6:
        repo.sortByFirstName();
        break;
}