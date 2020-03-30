using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.Configuration;
using Newtonsoft.Json;

namespace Nancy_REST
{
    public class RestModule : NancyModule
    {
        List<User> users = new List<User>()
        {
            new User() {Id = 1, Name = "Jumbo", Password = "2345"},
            new User() {Id = 2, Name = "Bimbo", Password = "2345"},
            new User() {Id = 3, Name = "Steve", Password = "2345"},
            new User() {Id = 4, Name = "Corentin", Password = "2345"},
            new User() {Id = 5, Name = "Lameboy$$$", Password = "2345"},
            new User() {Id = 6, Name = "Marabou", Password = "2345"},
            new User() {Id = 7, Name = "Biba", Password = "2345"},
            new User() {Id = 8, Name = "Mudak", Password = "2345"},
            new User() {Id = 9, Name = "CocoRo", Password = "2345"},
        };

        public RestModule()
        {
            Get("/", _ => "Welcome to the RESTful application my Niggaz!!!");
            
            Get("/users/{userId}", pars =>
            {
                var sob = users.Where(x => x.Id == pars.userId ).Select(x => new { Id = x.Id, Name = x.Name }).First();
                return JsonConvert.SerializeObject(sob);
            });

            Get("/users/", pars =>
            {
                var sob = users.Select(x => new { Id = x.Id, Name = x.Name });
                return JsonConvert.SerializeObject(sob);
            });

            Delete("/users/{userId}", pars =>
            {
                bool exists = users.Where(x => x.Id == pars.userId).Any();
                if (exists)
                {
                    users.Remove(users.Single(u => u.Id == pars.userId));
                    return "User has been successfully removed";
                }
                else
                {
                    return "Invalid UserId!";
                }
            });

            Put("/users/{name}/{pwd}", pars =>
            {
                int newId = users.Count + 1;
                users.Add(new User { Id = newId, Name = pars.name, Password = pars.pwd});
                return "New user created \n" + JsonConvert.SerializeObject(users.
                    Where(x => x.Name == pars.name).Single());
            });

            Post("/authentify/{name}/{pwd}", pars =>
            {
                bool exists = users.Where(x => x.Name == pars.name && x.Password == pars.pwd).Any();
                if (exists)
                {
                    return "Welcome to your account, beloved \n" + JsonConvert.SerializeObject(users.
                    Where(x => x.Name == pars.name && x.Password == pars.pwd).Single());
                }
                else
                {
                    return "Wrong credentials, you SOB!!!";
                }
            });

        }
    }
}
