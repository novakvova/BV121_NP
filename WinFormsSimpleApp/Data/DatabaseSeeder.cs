using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
   
}
