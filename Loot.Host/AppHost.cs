var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Loot_WebApi>("webapi");

var psql = builder.AddPostgres("loot")
    .WithDataVolume()
    .AddDatabase("loot-db");

builder.Build().Run();