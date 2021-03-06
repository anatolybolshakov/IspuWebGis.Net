namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(),
                        Rank = c.Int(nullable: false),
                        Address = c.String(),
                        Shape = c.Geometry(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Name = c.String(),
                        Mode = c.String(),
                        Time = c.DateTime(nullable: false),
                        Route = c.Geometry(),
                        isFavorite = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Forward = c.Short(nullable: false),
                        Backward = c.Short(nullable: false),
                        Speed = c.Short(nullable: false),
                        Shape = c.Geometry(),
                        ObjectId = c.Int(),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Points", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropIndex("dbo.Points", new[] { "TaskId" });
            DropTable("dbo.Roads");
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Points");
        }
    }
}
