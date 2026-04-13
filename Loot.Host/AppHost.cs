var builder = DistributedApplication.CreateBuilder(args);

var psql = builder.AddPostgres("loot")
    .WithDataVolume()
    .AddDatabase("loot-db");

var rabbitmq = builder.AddRabbitMQ("loot-rabbitmq")
    .WithDataVolume();

var mailDev = builder.AddContainer("maildev", "maildev/maildev")
    .WithHttpEndpoint(port: 1080, targetPort: 1080, name: "web")
    .WithEndpoint(port: 1025, targetPort: 1025, name: "smtp")
    .WithExternalHttpEndpoints();  

builder.AddProject<Projects.Loot_WebApi>("webapi")
    .WithReference(psql)
    .WaitFor(psql)
    .WithReference(rabbitmq)
    .WaitFor(rabbitmq)
    .WithReference(mailDev.GetEndpoint("smtp"))
    .WaitFor(mailDev);
builder.Build().Run();