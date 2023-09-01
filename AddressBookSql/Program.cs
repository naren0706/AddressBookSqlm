using System.Collections.Generic;

namespace AddressBookSql
{
    class Program
    {
        public static void Main(string[] args)
        {
            Operation operation = new Operation();
            //operation.CreateTable();
            //List<AddressBook> list = operation.CreateRecords();
            //operation.CreateRecords();
            AddressBook book = new AddressBook()
            {
                FirstName = "name2",
                LastName = "name2",
                Address = "street2",
                City = "UpdatedCity",
                State = "UpdatedState",
                Zip = "666666",
                PhoneNumber = "999999999",
                Email = "azasf@gmail.com"
            };
            //operation.UpdateDetails(book);
            //operation.GroupByCity();
            //operation.GroupByState();

            ////operation.SameCityDetails("Chennai");
            //operation.DeleteContact("name2");
            operation.GetCitySize();
            operation.GetStateSize();
        }
    }
}