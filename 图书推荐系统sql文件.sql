USE [master]
GO
/****** Object:  Database [图书推荐系统]    Script Date: 2020/6/27 20:24:25 ******/
CREATE DATABASE [图书推荐系统]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'图书推荐系统', FILENAME = N'D:\SQL\sqlproduct\图书推荐系统.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'图书推荐系统_log', FILENAME = N'D:\SQL\sqlproduct\图书推荐系统_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [图书推荐系统] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [图书推荐系统].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [图书推荐系统] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [图书推荐系统] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [图书推荐系统] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [图书推荐系统] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [图书推荐系统] SET ARITHABORT OFF 
GO
ALTER DATABASE [图书推荐系统] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [图书推荐系统] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [图书推荐系统] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [图书推荐系统] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [图书推荐系统] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [图书推荐系统] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [图书推荐系统] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [图书推荐系统] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [图书推荐系统] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [图书推荐系统] SET  DISABLE_BROKER 
GO
ALTER DATABASE [图书推荐系统] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [图书推荐系统] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [图书推荐系统] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [图书推荐系统] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [图书推荐系统] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [图书推荐系统] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [图书推荐系统] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [图书推荐系统] SET RECOVERY FULL 
GO
ALTER DATABASE [图书推荐系统] SET  MULTI_USER 
GO
ALTER DATABASE [图书推荐系统] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [图书推荐系统] SET DB_CHAINING OFF 
GO
ALTER DATABASE [图书推荐系统] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [图书推荐系统] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [图书推荐系统] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'图书推荐系统', N'ON'
GO
USE [图书推荐系统]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[AdmNo] [varchar](20) NOT NULL,
	[AdmName] [varchar](20) NOT NULL,
	[AdmSex] [char](2) NOT NULL,
	[AdmAddress] [varchar](40) NOT NULL,
	[AdmTelephone] [varchar](20) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[AdmNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
	[BookNo] [char](10) NOT NULL,
	[Publisher] [varchar](40) NOT NULL,
	[Variety] [varchar](40) NOT NULL,
	[BriefIntroduction] [text] NOT NULL,
	[BookName] [varchar](40) NOT NULL,
	[Auther] [varchar](40) NOT NULL,
	[WordNumber] [varchar](10) NOT NULL,
	[PublishYear] [datetime] NOT NULL,
	[Price] [money] NOT NULL,
	[BookThumb-up] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookShelf]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookShelf](
	[BookShelfNo] [varchar](20) NOT NULL,
	[BooKShelfName] [varchar](20) NOT NULL,
	[UserNumber] [varchar](10) NOT NULL,
 CONSTRAINT [PK_BookShelf] PRIMARY KEY CLUSTERED 
(
	[BookShelfNo] ASC,
	[UserNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookShelfContent]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookShelfContent](
	[BookShelfNo] [varchar](20) NOT NULL,
	[BookNo] [char](10) NOT NULL,
 CONSTRAINT [PK_BookShelfContent] PRIMARY KEY CLUSTERED 
(
	[BookShelfNo] ASC,
	[BookNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentNo] [varchar](10) NOT NULL,
	[CommentThumb-up] [varchar](10) NOT NULL,
	[Comments] [text] NOT NULL,
	[BookNo] [char](10) NOT NULL,
	[UserNumber] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Comment_1] PRIMARY KEY CLUSTERED 
(
	[CommentNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserNumber] [varchar](10) NOT NULL,
	[HeadPortrait] [nchar](10) NOT NULL,
	[Sex] [char](2) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[UserLevel] [varchar](5) NOT NULL CONSTRAINT [DF_Users_UserLevel]  DEFAULT ((1)),
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Form14Pinglun]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Form14Pinglun]
as  Select CommentNo as 书评码,[CommentThumb-up] as 点赞数,Comments as 评论,Users.UserNumber as 用户ID,UserName as 用户昵称,Comment.BookNo as 图书编号
    from Comment
    join Book on Comment.BookNo=Book.BookNo
    join Users on Comment.UserNumber=Users.UserNumber

GO
INSERT [dbo].[Administrator] ([AdmNo], [AdmName], [AdmSex], [AdmAddress], [AdmTelephone], [Password]) VALUES (N'01', N'裴某某', N'男', N'河北', N'18981355706', N'777777')
INSERT [dbo].[Administrator] ([AdmNo], [AdmName], [AdmSex], [AdmAddress], [AdmTelephone], [Password]) VALUES (N'02', N'汪某某', N'男', N'安徽', N'13333333335', N'456789')
INSERT [dbo].[Administrator] ([AdmNo], [AdmName], [AdmSex], [AdmAddress], [AdmTelephone], [Password]) VALUES (N'03', N'小李', N'男', N'成都', N'13258136888', N'852852')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000001   ', N'海南出版公司', N'小说', N'《百年孤独》，是哥伦比亚作家加西亚·马尔克斯创作的长篇小说，是其代表作，也是拉丁美洲魔幻现实主义文学的代表作，被誉为“再现拉丁美洲历史社会图景的鸿篇巨著”。
作品描写了布恩迪亚家族七代人的传奇故事，以及加勒比海沿岸小镇马孔多的百年兴衰，反映了拉丁美洲一个世纪以来风云变幻的历史。作品融入神话传说、民间故事、宗教典故等神秘因素，巧妙地糅合了现实与虚幻，展现出一个瑰丽的想象世界，成为20世纪重要的经典文学巨著之一。', N'百年孤独', N'马尔克斯', N'262千字', CAST(N'1967-01-01 00:00:00.000' AS DateTime), 38.0000, N'49')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000002   ', N'人民教育出版社', N'教材', N'君の日本語本当上手', N'标准日本语', N'工藤新一', N'462千字', CAST(N'2015-06-01 00:00:00.000' AS DateTime), 43.0000, N'20')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000003   ', N'湖南人民出版社', N'心理励志', N'摆脱抑郁，走出自闭全靠它', N'奔向幸福的旅程', N'谢勤', N'423千字', CAST(N'2018-06-01 00:00:00.000' AS DateTime), 32.0000, N'6')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000004   ', N'高等教育出版社', N'教材', N'时光又过去了十年，华东师范大学数学系编《数学分析（第四版）》（上、下册）于2010年7月由高等教育出版社出版发行，此版的编写组成员是：庞学诚（主编）、柴俊、胡善文、吴畏、毛羽辉。
相对于第三版，本版修改内容主要有：针对极限理论的内容过于集中、滞后的问题，这次通过提前得出“致密性定理”，使得闭区间上连续函数的全部性质能在第四章证明完毕； 针对目前很多大学不再单独开设数学分析习题课的现状，本次改版适当增加了稍有难度的例题，以期对学生解题能力的培养有所帮助；根据对第三版的使用反响，本版对“选读”和“必读”的内容作出了适当调整。', N'数学分析', N'陈纪修', N'620千字', CAST(N'2003-01-01 00:00:00.000' AS DateTime), 18.7000, N'85')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000005   ', N'印刷工业出版社', N'理论', N'控制自己，掌控敌人', N'自控力', N'凯利·麦格尼格尔', N'220千字', CAST(N'2012-08-01 00:00:00.000' AS DateTime), 39.8000, N'11')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000006   ', N'人民邮电出版社', N'教材', N'本书系统地讲述了数据库技术的基本原理和应用。全书共七章,主要内容包括:数据库系统概述、关系模型、SQL语言、关系数据库理论、数据库安全与保护、数据库设计和SQL Server 2000数据库管理系统。本书除介绍数据库技术的基本原理外,还以SQL Server 2000为背景介绍了数据库技术的实现,包括数据库和数据表的维护、查询与统计、视图管理、存储过程和触发器的管理、用户管理、约束和默认管理、数据库的备份和还原、Transact-SQL程序设计等内容,使读者可以充分利用SQL Server 2000平台深刻理解数据库技术的原理,达到理论和实践的紧密结合。', N'数据库原理及应用教程', N'陈志泊', N'335千字', CAST(N'2008-03-01 00:00:00.000' AS DateTime), 28.0000, N'80')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000007   ', N'华文出版社', N'励志与成功', N'所以我很寂寞', N'淡定的人生不寂寞', N'木木', N'220千字', CAST(N'2010-11-01 00:00:00.000' AS DateTime), 28.0000, N'66')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000008   ', N'高等教育出版社', N'教材', N'这样的拓扑你喜欢吗拓扑', N'点集拓扑讲义', N'熊金城', N'433千字', CAST(N'2011-06-01 00:00:00.000' AS DateTime), 15.0000, N'36')
INSERT [dbo].[Book] ([BookNo], [Publisher], [Variety], [BriefIntroduction], [BookName], [Auther], [WordNumber], [PublishYear], [Price], [BookThumb-up]) VALUES (N'0000009   ', N'浙江文艺出版社', N'小说', N'克总，发糖！', N'克苏鲁神话', N'H.P.洛夫克拉夫特', N'323千字', CAST(N'2016-11-01 00:00:00.000' AS DateTime), 50.0000, N'63')
INSERT [dbo].[BookShelf] ([BookShelfNo], [BooKShelfName], [UserNumber]) VALUES (N'...', N'新建', N'999999')
INSERT [dbo].[BookShelf] ([BookShelfNo], [BooKShelfName], [UserNumber]) VALUES (N'123', N'大学必备', N'100001')
INSERT [dbo].[BookShelf] ([BookShelfNo], [BooKShelfName], [UserNumber]) VALUES (N'124', N'励志的书', N'100001')
INSERT [dbo].[BookShelf] ([BookShelfNo], [BooKShelfName], [UserNumber]) VALUES (N'125', N'科幻世界', N'100002')
INSERT [dbo].[BookShelf] ([BookShelfNo], [BooKShelfName], [UserNumber]) VALUES (N'126', N'经典名著', N'100002')
INSERT [dbo].[BookShelf] ([BookShelfNo], [BooKShelfName], [UserNumber]) VALUES (N'129', N'编程', N'100001')
INSERT [dbo].[BookShelf] ([BookShelfNo], [BooKShelfName], [UserNumber]) VALUES (N'130', N'数据库', N'100001')
INSERT [dbo].[BookShelfContent] ([BookShelfNo], [BookNo]) VALUES (N'123', N'0000006   ')
INSERT [dbo].[BookShelfContent] ([BookShelfNo], [BookNo]) VALUES (N'124', N'0000003   ')
INSERT [dbo].[BookShelfContent] ([BookShelfNo], [BookNo]) VALUES (N'124', N'0000007   ')
INSERT [dbo].[BookShelfContent] ([BookShelfNo], [BookNo]) VALUES (N'125', N'0000009   ')
INSERT [dbo].[BookShelfContent] ([BookShelfNo], [BookNo]) VALUES (N'126', N'0000006   ')
INSERT [dbo].[BookShelfContent] ([BookShelfNo], [BookNo]) VALUES (N'129', N'0000006   ')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'101', N'1', N'好书，很详细', N'0000006   ', N'100001')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'102', N'2', N'配合老师教学，学到很多东西', N'0000006   ', N'100001')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'103', N'0', N'知识很丰富', N'0000004   ', N'100001')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'104', N'2', N'好书！', N'0000006   ', N'100003')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'106', N'0', N'期待下一版', N'0000006   ', N'100003')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'107', N'0', N'太好看了吧', N'0000009   ', N'100003')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'108', N'0', N'心里好多了', N'0000003   ', N'100003')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'109', N'0', N'谢谢', N'0000003   ', N'100003')
INSERT [dbo].[Comment] ([CommentNo], [CommentThumb-up], [Comments], [BookNo], [UserNumber]) VALUES (N'110', N'0', N'太棒了！！', N'0000006   ', N'100001')
INSERT [dbo].[Users] ([UserNumber], [HeadPortrait], [Sex], [UserName], [UserLevel], [Password]) VALUES (N'100001', N'4         ', N'女', N'叶某某', N'3', N'123456')
INSERT [dbo].[Users] ([UserNumber], [HeadPortrait], [Sex], [UserName], [UserLevel], [Password]) VALUES (N'100002', N'2         ', N'男', N'裴某某', N'1', N'333333')
INSERT [dbo].[Users] ([UserNumber], [HeadPortrait], [Sex], [UserName], [UserLevel], [Password]) VALUES (N'100003', N'3         ', N'男', N'邓某某', N'3', N'888888')
INSERT [dbo].[Users] ([UserNumber], [HeadPortrait], [Sex], [UserName], [UserLevel], [Password]) VALUES (N'100006', N'4         ', N'男', N'汪某某', N'1', N'555555')
INSERT [dbo].[Users] ([UserNumber], [HeadPortrait], [Sex], [UserName], [UserLevel], [Password]) VALUES (N'100007', N'2         ', N'男', N'小明', N'1', N'999999')
ALTER TABLE [dbo].[Comment]  WITH NOCHECK ADD  CONSTRAINT [FK_Comment_Book] FOREIGN KEY([BookNo])
REFERENCES [dbo].[Book] ([BookNo])
GO
ALTER TABLE [dbo].[Comment] NOCHECK CONSTRAINT [FK_Comment_Book]
GO
ALTER TABLE [dbo].[Comment]  WITH NOCHECK ADD  CONSTRAINT [FK_Comment_Users] FOREIGN KEY([UserNumber])
REFERENCES [dbo].[Users] ([UserNumber])
GO
ALTER TABLE [dbo].[Comment] NOCHECK CONSTRAINT [FK_Comment_Users]
GO
/****** Object:  StoredProcedure [dbo].[form12sousuo]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[form12sousuo]
(@TextBox1 varchar(40))
as
select BookName as 书名,BookShelfContent.BookNo as 图书编码,UserName as 用户昵称,BookShelfName as 书单
from Bookshelf
join BookShelfContent
on Bookshelf.BookShelfNo = BookShelfContent.BookShelfNo
join Book on BookShelfContent.BookNo = Book.BookNo
join Users on BookShelf.UserNumber = Users.UserNumber
where BookShelfName like @TextBox1 or UserName like @TextBox1
GO
/****** Object:  StoredProcedure [dbo].[form1denglu]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[form1denglu]
(@UserNumber Varchar(20),
@Password Varchar(50))
as
select count(*)
from Users 
where UserNumber = @UserNumber  and Password=  @Password
GO
/****** Object:  StoredProcedure [dbo].[form1denglu2]    Script Date: 2020/6/27 20:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[form1denglu2]
(@account Varchar(20),
@password Varchar(50))
as
select count(*)
from Administrator 
where AdmNo = @account and Password= @password
GO
USE [master]
GO
ALTER DATABASE [图书推荐系统] SET  READ_WRITE 
GO
