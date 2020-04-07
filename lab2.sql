CREATE DATABASE [lab2]
GO

USE [lab2]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[clients] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [FIO]   VARCHAR (256) NOT NULL,
    [phone] VARCHAR (15)  NOT NULL
);


USE [lab2]
GO

/****** Iauaeo: Table [dbo].[services] Aaoa ne?eioa: 07.04.2020 17:34:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[services] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [name]  VARCHAR (256) NULL,
    [price] INT           NOT NULL
);


USE [lab2]
GO

/****** Iauaeo: Table [dbo].[tickets] Aaoa ne?eioa: 07.04.2020 17:34:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tickets] (
    [id]       INT IDENTITY (1, 1) NOT NULL,
    [clientId] INT NOT NULL
);


USE [lab2]
GO

/****** Iauaeo: Table [dbo].[ticketService] Aaoa ne?eioa: 07.04.2020 17:34:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ticketService] (
    [ticketId]  INT NOT NULL,
    [serviceId] INT NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [ticketservice]
    ON [dbo].[ticketService]([ticketId] ASC, [serviceId] ASC);


GO
ALTER TABLE [dbo].[ticketService]
    ADD CONSTRAINT [PK_ticketService] PRIMARY KEY CLUSTERED ([serviceId] ASC, [ticketId] ASC);

GO
ALTER TABLE [dbo].[ticketService]
    ADD CONSTRAINT [FK_ticketService_ToTable] FOREIGN KEY ([ticketId]) REFERENCES [dbo].[tickets] ([id]);


GO
ALTER TABLE [dbo].[ticketService]
    ADD CONSTRAINT [FK_ticketService_ToTable_1] FOREIGN KEY ([serviceId]) REFERENCES [dbo].[services] ([id]);


