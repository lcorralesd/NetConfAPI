﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetConfAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetConfAPI.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(ix => ix.Name).IsUnique();
            builder.HasData(new Category { Id = 1, Description = "Viveres", Name = "Viveres", Picture = "" });
        }
    }
}
