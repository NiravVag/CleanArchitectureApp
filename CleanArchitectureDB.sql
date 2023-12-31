USE [CleanArchitectureDB]
GO
/****** Object:  Table [dbo].[LoginLog]    Script Date: 23-06-2023 3:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginLogId] [uniqueidentifier] NOT NULL,
	[LoginDate] [datetime2](7) NULL,
	[LoginSuccess] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23-06-2023 3:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](150) NULL,
	[Password] [nvarchar](100) NULL,
	[Address] [nvarchar](250) NULL,
	[LastLogin] [datetime] NULL,
	[UserName] [varchar](200) NULL,
	[UserStatusId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserToken]    Script Date: 23-06-2023 3:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserTokenId] [uniqueidentifier] NULL,
	[Token] [nvarchar](max) NOT NULL,
	[JwtToken] [nvarchar](max) NOT NULL,
	[Expires] [datetime] NULL,
	[ReplacedByToken] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[RevokedDate] [datetime] NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK__UserToke__3214EC07A5A38CE8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_usersedit]    Script Date: 23-06-2023 3:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_usersedit] 
	@Id					BIGINT=NULL,
	@FirstName			NVARCHAR(30)=NULL,
	@LastName			NVARCHAR(30)=NULL,
	@Email		NVARCHAR(150)=NULL,
	@Password			NVARCHAR(100)=NULL,
	@Address			NVARCHAR(250)=NULL,
	@Option				NVARCHAR(20)
AS
BEGIN
	IF @Option = 'ADD'
	BEGIN
		INSERT INTO Users(FirstName,LastName,Email,[Password],[Address])
		VALUES(@FirstName,@LastName,@Email,@Password,@Address)
		--SET @RetVal=@@IDENTITY
		SELECT 'Data saved successfully.' AS [MESSAGE];
	END

	ELSE IF @Option = 'EDIT'
	BEGIN
		UPDATE Users
		SET
			FirstName=@FirstName,
			LastName=@LastName,
			Email=@Email,
			[Password]=@Password,
			[Address]=@Address

		WHERE Id=@Id
		--SET @RetVal=@Id
		SELECT 'Updated' AS [MESSAGE];
	END

	ELSE IF @Option = 'DELETE'
	BEGIN
		DELETE FROM Users
		WHERE Id=@Id
		--SET @RetVal=@Id
		SELECT 'Deleted' AS [MESSAGE];
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_usersselect]    Script Date: 23-06-2023 3:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

-- [dbo].[sp_usersselect] '1'
CREATE PROCEDURE [dbo].[sp_usersselect] 
	@Id			BIGINT
AS
BEGIN
	SELECT
		ISNULL(u.Id, 0)AS Id,
		ISNULL(u.FirstName, '')AS FirstName,
		ISNULL(u.LastName, '')AS LastName,
		ISNULL(u.Email, '')AS Email,
		ISNULL(u.[Password], '')AS [Password],
		(ISNULL(u.FirstName,'')+' '+ISNULL(u.LastName,'')) AS FullName,
		ISNULL(u.[Address], '')AS [Address]

		FROM
			Users u
		WHERE
		(@Id=-1 OR Id=@Id)
END
GO
