insert into CommandItems (HowTo, Platform, CommandLine)
values ('Create an EF migration', 'Entity Framework Core Command Line','dotnet ef migrations add');
insert into CommandItems (HowTo, Platform, CommandLine)
VALUES ('Apply Migrations to DB', 'Entity Framework Core Command Line', 'dotnet ef database update');

insert into CommandItems (HowTo, Platform, CommandLine)
values ('Build Application', 'Entity Framework Core Command Line','dotnet build');
insert into CommandItems (HowTo, Platform, CommandLine)
values ('Run Application', 'Entity Framework Core Command Line','dotnet run');

insert into CommandItems (HowTo, Platform, CommandLine) values ('Add Code', 'Git Command Line','git add .');
insert into CommandItems (HowTo, Platform, CommandLine) values ('Git Code Status', 'Git Command Line','git status');
insert into CommandItems (HowTo, Platform, CommandLine) values ('Commit Code to lcal repository', 'Git Command Line','git commit -m "Initial Commit"');
insert into CommandItems (HowTo, Platform, CommandLine) values ('Push Code to GitHub master branch', 'Git Command Line','git push origin master');

select * from CommandItems