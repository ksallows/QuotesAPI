namespace QuotesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quotes", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Quotes", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Quotes", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Quotes", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quotes", "Type", c => c.String());
            AlterColumn("dbo.Quotes", "Description", c => c.String());
            AlterColumn("dbo.Quotes", "Author", c => c.String());
            AlterColumn("dbo.Quotes", "Title", c => c.String());
        }
    }
}
