using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPIService.Tests.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }

        public User()
        { }

        public User(int _id, string _name, string _username, string _email, string _phone, string _website, Address _address, Company _company)
        {
            this.Id = _id;
            this.Name = _name;
            this.Username = _username;
            this.Email = _email;
            this.Phone = _phone;
            this.Website = _website;

            this.Address = new Address(_address.Street, _address.Suite, _address.City, _address.Zipcode, new Geo(_address.Geo.Lat, _address.Geo.Lng));
            this.Company = new Company(_company.Name, _company.CatchPhrase, _company.Bs);
        }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public Geo Geo { get; set; }

        public Address()
        { }

        public Address(string _street, string _suite, string _city, string _zipcode, Geo _geo)
        {
            this.Street = _street;
            this.Suite = _suite;
            this.City = _city;
            this.Zipcode = _zipcode;
            this.Geo = new Geo(_geo.Lat, _geo.Lng);
        }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public Geo()
        { }

        public Geo(string _lat, string _lng)
        {
            this.Lat = _lat;
            this.Lng = _lng;
        }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public Company()
        { }

        public Company(string _name, string _catchphrase, string _bs)
        {
            this.Name = _name;
            this.CatchPhrase = _catchphrase;
            this.Bs = _bs;
        }
    }
}