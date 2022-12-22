using Bogus;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsSimpleApp.Constants;
using WinFormsSimpleApp.Data.Entities;

namespace WinFormsSimpleApp.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed()
        {
            using(MyDataContext dataContext= new MyDataContext())
            {
                SeedCategories(dataContext);
                SeedUsers(dataContext);
                SeedRoles(dataContext);
            }
        }
        private static void SeedCategories(MyDataContext dataContext)
        {
            if(!dataContext.Categories.Any())
            {
                var notebook = new CategoryEntity
                {
                    Title = "Ноутбуки та комп’ютери",
                    DateCreated = DateTime.Now,
                    Priority = 1
                };
                var bt = new CategoryEntity
                {
                    Title = "Побутова техніка",
                    DateCreated = DateTime.Now,
                    Priority = 2
                };
                dataContext.Categories.Add(notebook);
                dataContext.Categories.Add(bt);
                dataContext.SaveChanges();
                string[] note_childs = { "Ноутбуки", "Комп'ютери, неттопи, моноблоки", 
                    "Монітори", "Планшети"};
                int count = 1;
                foreach(var note in note_childs) {
                    var cat = new CategoryEntity
                    {
                        Title = "Ноутбуки та комп’ютери",
                        DateCreated = DateTime.Now,
                        Priority = count,
                        ParentId=notebook.Id
                    };
                    dataContext.Categories.Add(cat);
                    dataContext.SaveChanges();
                    count++;
                }
            }
        }

        private static void SeedUsers(MyDataContext dataContext)
        {
            if (!dataContext.Users.Any())
            {
                var faker = new Faker<UserEntity>("uk")
                    .RuleFor(u => u.Name, f => f.Name.FullName())
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
                    .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
                    .RuleFor(u => u.Photo, f => f.Image.LoremFlickrUrl());
                int n = 20;
                for (int i = 0; i < n; i++)
                {
                    var user = faker.Generate();
                    dataContext.Users.Add(user);
                    dataContext.SaveChanges();
                }
            }
        }

        private static void SeedRoles(MyDataContext dataContext)
        {
            if (!dataContext.Roles.Any())
            {
                dataContext.Roles.Add(new RoleEntity { Name = Roles.Admin });
                dataContext.Roles.Add(new RoleEntity { Name = Roles.User });
                dataContext.SaveChanges();
            }
        }
    }
   
}
