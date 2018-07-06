namespace EF_Formation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_Group_One_to_Many : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Group3Id = c.Long(nullable: false),
                        Group4Id = c.Long(),
                        Group1_Id = c.Long(),
                        Group2_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group1_Id)
                .ForeignKey("dbo.Groups", t => t.Group2_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group3Id)
                .ForeignKey("dbo.Groups", t => t.Group4Id)
                .Index(t => t.Group3Id)
                .Index(t => t.Group4Id)
                .Index(t => t.Group1_Id)
                .Index(t => t.Group2_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Group4Id", "dbo.Groups");
            DropForeignKey("dbo.Students", "Group3Id", "dbo.Groups");
            DropForeignKey("dbo.Students", "Group2_Id", "dbo.Groups");
            DropForeignKey("dbo.Students", "Group1_Id", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "Group2_Id" });
            DropIndex("dbo.Students", new[] { "Group1_Id" });
            DropIndex("dbo.Students", new[] { "Group4Id" });
            DropIndex("dbo.Students", new[] { "Group3Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Groups");
        }
    }
}
