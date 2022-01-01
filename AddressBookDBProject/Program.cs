using AddressBookDBProject;
AddressBookModel addressBookmodel = new AddressBookModel();
AddressBookRepo repo = new AddressBookRepo();
Console.WriteLine("\t-----Welcome To Addressbook Management System------");
Console.WriteLine("\t-----1. To add------");
Console.WriteLine("\t-----2. To Edit------");
Console.WriteLine("\t-----3. To Delete------");
int choice=Convert.ToInt32(Console.ReadLine());
switch (choice) {
    case 1:


addressBookmodel.firstname="Dablu";
addressBookmodel.lastname="Paswan";
addressBookmodel.address="At+Post-Sunday Bazar";
addressBookmodel.city="Bermo";
addressBookmodel.state="Jharkhand";
addressBookmodel.zip=2232;
addressBookmodel.phonenumber="1231414";
addressBookmodel.email="dablu@gmail.com";

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
}