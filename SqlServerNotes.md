# SQL Server Notes

Disclaimer: Sorry for my broken English

## Installation 

SQL Server installation was a bit chaotic for me. Here are some tips to help you below.
- No specific version is required.
- Install the developer version.
- Create an SQL Server instance. 
    - Do not forget to configure your instance in MIXED SECURITY.
    - Do not forget your password.
    - Do not forget to add your window account as SQL Server instance administrator.
- You need to install SSMS "Microsoft SQL Server Management Studio" (latest as possible)

> Personal configuration:
>  - Window 10
>  - SQL Server 2019 (dev)
>  - SSMS 2019
>
> The connection string in my soluce use the "trusted_connection=true". This means I don't have to write down my username and password.
>
> You may need this syntax below. (Look the queries section to know if you can use the trusted_connection)
>    ```json
>    "ConnectionStrings": { "RecipesConnectionString": "Data Source=SERVER;Initial Catalog=DATABASE;User id=USER;Password=PASSWORD" }
>    ```


## Queries

Here, some queries that I used for this project.

### ConnectionString builder

```sql
select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()
```

### Generate Recipe table

```sql
CREATE TABLE Recipe
(
    id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
    title varchar(100) not null, 
);
```

### Generate some values in Recipe

```sql
INSERT INTO Recipe VALUES
(default, 'SQL Recipe 01'),
(default, 'SQL Recipe 02'),
(default, 'SQL Recipe 03'),
(default, 'SQL Recipe 04'),
(default, 'SQL Recipe 05');
```

### Read the values in Recipe

```sql 
SELECT * FROM Recipe;
```

### Generate a stored procedure

```sql
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ToPin060>
-- Create date: <XX/XX/XXXX>/
-- Description:	<N/A>
-- =============================================
CREATE PROCEDURE SelectRecipe
AS
BEGIN
SET NOCOUNT ON;
	SELECT * FROM Recipe ORDER BY title
END
GO
```

> You can generate a template directly: DATABASE > Programmability > Stored Procedures > Right click > New... > Stored Procedure...

### Modify the previous stored procedure

```sql
GO
/****** Object:  StoredProcedure [dbo].[SelectRecipe]    Script Date: 01/03/2024 17:57:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ToPin060>
-- Create date: <XX/XX/XXXX>/
-- Description:	<N/A>
-- =============================================
ALTER PROCEDURE [dbo].[SelectRecipe]
	@Title nvarchar(100) = NULL
AS
BEGIN
SET NOCOUNT ON;
	SELECT *
	FROM Recipe
	WHERE (@Title IS NULL OR title LIKE '%' + @Title + '%')
	ORDER BY title;
END
```