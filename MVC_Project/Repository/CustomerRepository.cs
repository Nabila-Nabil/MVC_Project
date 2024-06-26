﻿using MVC_Project.Interfaces;

namespace MVC_Project.Repository
{
    public class CustomerRepository :ICustomer
    {
        BookStoreContext bookStoreContext;
        public CustomerRepository(BookStoreContext _bookStoreContext)
        {
            bookStoreContext = _bookStoreContext;
        }

        public void DeleteCustomer(string id)
        {
            Customer customer = bookStoreContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            bookStoreContext.Customers.Remove(customer);
        }

        public void Save()
        {
            bookStoreContext.SaveChanges();
        }

        public void UpdateCustomer(string id)
        {
            Customer customer = bookStoreContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            bookStoreContext.Customers.Update(customer);
        }

        List<Customer> ICustomer.GetAllCustomers()
        {
            List<Customer> customers = bookStoreContext.Customers.ToList();
            return customers;
        }

        Customer ICustomer.GetCustomerById(string id)
        {
            Customer customer = bookStoreContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            return customer;
        }

        void ICustomer.InsertCustomer(Customer customer)
        {
            bookStoreContext.Customers.Add(customer);
        }

		

        public List<Customer> GetCustomersByName(string name)
        {
            var keywords = name.Split(new char[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);

            var customers = bookStoreContext.Customers
                .Where(c => keywords.Any(k => c.FullName.Contains(k)))
                .ToList();
            return customers;
        }



	}
}
