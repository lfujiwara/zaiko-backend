using System;

namespace Zaiko.Models
{
    public class Product
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Product(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Product(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public void setName(string name)
        {
            Name = name;
        }

        public void setDescription(string description)
        {
            Description = description;
        }
    }
}