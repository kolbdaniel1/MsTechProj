
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/24/2014 11:29:48
-- Generated from EDMX file: \\psf\Home\Documents\Visual Studio 2013\Projects\MsTechProj\AutoReservation.Dal\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AutoReservation];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Reservation_Auto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservation] DROP CONSTRAINT [FK_Reservation_Auto];
GO
IF OBJECT_ID(N'[dbo].[FK_Reservation_Kunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservation] DROP CONSTRAINT [FK_Reservation_Kunde];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Auto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auto];
GO
IF OBJECT_ID(N'[dbo].[Kunde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kunde];
GO
IF OBJECT_ID(N'[dbo].[Reservation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservation];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Autos'
CREATE TABLE [dbo].[Autos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Marke] nvarchar(20)  NOT NULL,
    [AutoKlasse] int  NOT NULL,
    [Tagestarif] int  NOT NULL
);
GO

-- Creating table 'Kundens'
CREATE TABLE [dbo].[Kundens] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nachname] nvarchar(20)  NOT NULL,
    [Vorname] nvarchar(20)  NOT NULL,
    [Geburtsdatum] datetime  NOT NULL
);
GO

-- Creating table 'Reservationens'
CREATE TABLE [dbo].[Reservationens] (
    [ReservationNr] int IDENTITY(1,1) NOT NULL,
    [AutoId] int  NOT NULL,
    [KundeId] int  NOT NULL,
    [Von] datetime  NOT NULL,
    [Bis] datetime  NOT NULL
);
GO

-- Creating table 'Autos_LuxusklasseAutos'
CREATE TABLE [dbo].[Autos_LuxusklasseAutos] (
    [Basistarif] int  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Autos_MittelklasseAutos'
CREATE TABLE [dbo].[Autos_MittelklasseAutos] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Autos_StandardAuto'
CREATE TABLE [dbo].[Autos_StandardAuto] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Autos'
ALTER TABLE [dbo].[Autos]
ADD CONSTRAINT [PK_Autos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kundens'
ALTER TABLE [dbo].[Kundens]
ADD CONSTRAINT [PK_Kundens]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ReservationNr] in table 'Reservationens'
ALTER TABLE [dbo].[Reservationens]
ADD CONSTRAINT [PK_Reservationens]
    PRIMARY KEY CLUSTERED ([ReservationNr] ASC);
GO

-- Creating primary key on [Id] in table 'Autos_LuxusklasseAutos'
ALTER TABLE [dbo].[Autos_LuxusklasseAutos]
ADD CONSTRAINT [PK_Autos_LuxusklasseAutos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Autos_MittelklasseAutos'
ALTER TABLE [dbo].[Autos_MittelklasseAutos]
ADD CONSTRAINT [PK_Autos_MittelklasseAutos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Autos_StandardAuto'
ALTER TABLE [dbo].[Autos_StandardAuto]
ADD CONSTRAINT [PK_Autos_StandardAuto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AutoId] in table 'Reservationens'
ALTER TABLE [dbo].[Reservationens]
ADD CONSTRAINT [FK_Reservation_Auto]
    FOREIGN KEY ([AutoId])
    REFERENCES [dbo].[Autos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservation_Auto'
CREATE INDEX [IX_FK_Reservation_Auto]
ON [dbo].[Reservationens]
    ([AutoId]);
GO

-- Creating foreign key on [KundeId] in table 'Reservationens'
ALTER TABLE [dbo].[Reservationens]
ADD CONSTRAINT [FK_Reservation_Kunde]
    FOREIGN KEY ([KundeId])
    REFERENCES [dbo].[Kundens]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservation_Kunde'
CREATE INDEX [IX_FK_Reservation_Kunde]
ON [dbo].[Reservationens]
    ([KundeId]);
GO

-- Creating foreign key on [Id] in table 'Autos_LuxusklasseAutos'
ALTER TABLE [dbo].[Autos_LuxusklasseAutos]
ADD CONSTRAINT [FK_LuxusklasseAutos_inherits_Autos]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Autos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Autos_MittelklasseAutos'
ALTER TABLE [dbo].[Autos_MittelklasseAutos]
ADD CONSTRAINT [FK_MittelklasseAutos_inherits_Autos]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Autos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Autos_StandardAuto'
ALTER TABLE [dbo].[Autos_StandardAuto]
ADD CONSTRAINT [FK_StandardAuto_inherits_Autos]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Autos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------