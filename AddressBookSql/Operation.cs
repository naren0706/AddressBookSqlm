﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AddressBookSql
{
    internal class Operation
    {
        public static Random R = new Random();
        private SqlConnection con;
        public void CreateDataBase()
        {
            con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=master; integrated Security= true");
            try
            {
                string query = "Create Database AddressBook";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("DataBase Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no database created ");
            }
            finally
            {
                con.Close();
            }
        }
        private void Connection()
        {
            string connectionstr = "data source = (localdb)\\MSSQLLocalDB; initial catalog = AddressBook; integrated security = true";
            con = new SqlConnection(connectionstr);
        }
        public void CreateTable()
        {
            try
            {
                Connection();
                string query = "create Table address_book(Id int primary key identity(1,1),FirstName varchar(max) not null,LastNames varchar(max) not null,Address varchar(max) not null,City varchar(max) not null,State varchar(max) not null,Zip varchar(max) not null,PhoneNumber varchar(max) not null,Email varchar(max) not null);";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Table is not created ");
            }
            finally
            {
                con.Close();
            }
        }
        public List<AddressBook> CreateRecords()
        {
            List<AddressBook> list = new List<AddressBook>();
            string[] city = { "Chennai", "Coimbatore", "Madurai" };
            string[] state = { "TamilNadu", "Kerala", "Delhi" };
            string[] zip = { "641654", "600004", "600032" };

            for (int i = 0; i < 50; i++)
            {
                AddressBook details = new AddressBook()
                {
                    FirstName = "name" + i,
                    LastName = "name" + i,
                    Address = "street" + i,
                    City = city[R.Next(3)],
                    State = state[R.Next(3)],
                    Zip = zip[R.Next(3)],
                    PhoneNumber = "9" + R.Next(10000000, 999999999),
                    Email = "azasf@gmail.com"
                };
                list.Add(details);
                AddEmployeeDetails(details);
            }
            return list;
        }

        public void AddEmployeeDetails(AddressBook details)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("AddAddressBookDetail", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", details.FirstName);
                com.Parameters.AddWithValue("@LastName", details.LastName);
                com.Parameters.AddWithValue("@Address", details.Address);
                com.Parameters.AddWithValue("@City", details.City);
                com.Parameters.AddWithValue("@State", details.State);
                com.Parameters.AddWithValue("@Zip", details.Zip);
                com.Parameters.AddWithValue("@PhoneNumber", details.PhoneNumber);
                com.Parameters.AddWithValue("@Email", details.Email);
                con.Open();
                var i = com.ExecuteScalar();
                Console.WriteLine("Database Added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateDetails(AddressBook contact)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("EditContactDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", contact.FirstName);
                com.Parameters.AddWithValue("@LastName", contact.LastName);
                com.Parameters.AddWithValue("@Address", contact.Address);
                com.Parameters.AddWithValue("@City", contact.City);
                com.Parameters.AddWithValue("@State", contact.State);
                com.Parameters.AddWithValue("@Zip", contact.Zip);
                com.Parameters.AddWithValue("@Phonenumber", contact.PhoneNumber);
                com.Parameters.AddWithValue("@Email", contact.Email);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("DataBase Updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
<<<<<<< HEAD

        internal void GroupByCity()
        {
            Connection();

            SqlCommand com = new SqlCommand("GroupByCity", con);

            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.Write("values for " + Convert.ToString(dr["City"]) + " is");
                Console.WriteLine(" Count : " + Convert.ToString(dr["count"]));
            }
        }
        internal void GroupByState()
        {
            Connection();

            SqlCommand com = new SqlCommand("GroupByState", con);

            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.Write("values for " + Convert.ToString(dr["State"]) + " is");
                Console.WriteLine(" Count : " + Convert.ToString(dr["count"]));
            }
        }

        internal void GetCitySize()
=======
        public void DeleteContact(string firstName)
>>>>>>> 165f2e0f1c5d9138c807d9ade038cce6758dbb16
        {
            try
            {
                Connection();
<<<<<<< HEAD
                SqlCommand com = new SqlCommand("CountinCity", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                int i = com.ExecuteNonQuery();
                List<AddressBook> contacts = new List<AddressBook>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                Console.WriteLine("The No of persons in the Each city are ");
                foreach (DataRow dr in dt.Rows)
                {
                     Console.WriteLine(Convert.ToString(dr["city"]));
                     Console.WriteLine(Convert.ToString(dr["count"]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        internal void GetStateSize()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("CountinState", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                int i = com.ExecuteNonQuery();
                List<AddressBook> contacts = new List<AddressBook>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                Console.WriteLine("The No of persons in the Each city are ");
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine(Convert.ToString(dr["state"]));
                    Console.WriteLine(Convert.ToString(dr["count"]));
                }
=======
                SqlCommand com = new SqlCommand("DeleteContactDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", firstName);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("Database Deleted");
>>>>>>> 165f2e0f1c5d9138c807d9ade038cce6758dbb16
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
