using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Models.Context;

public class MyApiContext : DbContext
{
    public MyApiContext(DbContextOptions<MyApiContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}