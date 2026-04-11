var builder = DistributedApplication.CreateBuilder(args);

var psql = builder.AddPostgres("loot")
    .WithDataVolume()
    .AddDatabase("loot-db");

builder.Build().Run();