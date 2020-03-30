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
        public RestModule()
        {
            Get("/", _ => "Welcome to the RESTful application my Niggaz!!!");
            
            Get("/users/{userId}", pars =>
            {
                using (var context = new UserContext())
                {
                    var users = context.Users.ToList();
                    var sob = users.Where(x => x.UserId == pars.userId).Select(x => new { Id = x.UserId, Name = x.Name }).First();
                    return JsonConvert.SerializeObject(sob);
                }
            });

            Get("/users/", pars =>
            {
                using (var context = new UserContext())
                {
                    var users = context.Users.ToList();
                    var sob = users.Select(x => new { Id = x.UserId, Name = x.Name });
                    return JsonConvert.SerializeObject(sob);
                }
            });

            Delete("/users/{userId}", pars =>
            {
                using (var context = new UserContext())
                {
                    var users = context.Users.ToList();
                    bool exists = users.Where(x => x.UserId == pars.userId).Any();
                    if (exists)
                    {
                        var user = users.Where(x => x.UserId == pars.userId).First();
                        context.Users.Remove(user);
                        context.SaveChanges();
                        return "User has been successfully removed";
                    }
                    else
                    {
                        return "Invalid UserId!";
                    }
                }
                
            });

            Put("/users/{name}/{pwd}", pars =>
            {
                using (var context = new UserContext())
                {
                    var users = context.Users.ToList();
                    //int newId = users.Count + 1;
                    context.Add(new User { Name = pars.name, Password = pars.pwd });
                    context.SaveChanges();
                    return "New user successfully created!";
                }

                
            });

            Post("/authentify/{name}/{pwd}", pars =>
            {
                using (var context = new UserContext())
                {
                    var users = context.Users.ToList();
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
                }             
            });

        }
    }
}
