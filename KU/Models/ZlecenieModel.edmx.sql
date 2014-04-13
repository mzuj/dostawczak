
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2014 22:02:59
-- Generated from EDMX file: C:\Users\TomekI\Documents\Visual Studio 2013\Projects\KU\KU\Models\ZlecenieModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MVCCourier];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ZleceniePowodOdrzucenia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zlecenie] DROP CONSTRAINT [FK_ZleceniePowodOdrzucenia];
GO
IF OBJECT_ID(N'[dbo].[FK_ZleceniePowodPrzelozenia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zlecenie] DROP CONSTRAINT [FK_ZleceniePowodPrzelozenia];
GO
IF OBJECT_ID(N'[dbo].[FK_ZlecenieRodzajOpakowania]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zlecenie] DROP CONSTRAINT [FK_ZlecenieRodzajOpakowania];
GO
IF OBJECT_ID(N'[dbo].[FK_ZlecenieRodzajZlecenia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zlecenie] DROP CONSTRAINT [FK_ZlecenieRodzajZlecenia];
GO
IF OBJECT_ID(N'[dbo].[FK_ZlecenieStatusZlecenie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zlecenie] DROP CONSTRAINT [FK_ZlecenieStatusZlecenie];
GO
IF OBJECT_ID(N'[dbo].[FK_ZlecenieZawartosc]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zlecenie] DROP CONSTRAINT [FK_ZlecenieZawartosc];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[PowodOdrzucenia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PowodOdrzucenia];
GO
IF OBJECT_ID(N'[dbo].[PowodPrzelozeniaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PowodPrzelozeniaSet];
GO
IF OBJECT_ID(N'[dbo].[RodzajOpakowania]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RodzajOpakowania];
GO
IF OBJECT_ID(N'[dbo].[RodzajZleceniaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RodzajZleceniaSet];
GO
IF OBJECT_ID(N'[dbo].[StatusZlecenie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatusZlecenie];
GO
IF OBJECT_ID(N'[dbo].[Zawartosc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zawartosc];
GO
IF OBJECT_ID(N'[dbo].[Zlecenie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zlecenie];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [UserId] nvarchar(128)  NOT NULL,
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Zlecenie'
CREATE TABLE [dbo].[Zlecenie] (
    [ZlecenieID] int IDENTITY(1,1) NOT NULL,
    [Miejsce_nadania] nvarchar(100)  NOT NULL,
    [Miejsce_dostawy] nvarchar(100)  NOT NULL,
    [Odbiorca] nvarchar(100)  NOT NULL,
    [Zleceniodawca] nvarchar(100)  NOT NULL,
    [Ilosc_opakowan] int  NULL,
    [Materialy_niebezpieczne] bit  NOT NULL,
    [Pobranie_za_przesylke] bit  NOT NULL,
    [Priorytet] bit  NOT NULL,
    [Kurier] nvarchar(128)  NULL,
    [Status] int  NOT NULL,
    [Komentarz_kuriera] nvarchar(max)  NULL,
    [Komentarz_nadawcy] nvarchar(max)  NULL,
    [RodzajOpakowaniaId] int  NULL,
    [ZawartoscId] int  NULL,
    [PowodOdrzuceniaId] int  NULL,
    [PowodPrzelozeniaId] int  NULL,
    [RodzajZleceniaId] int  NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [User_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'StatusZlecenie'
CREATE TABLE [dbo].[StatusZlecenie] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'PowodOdrzucenia'
CREATE TABLE [dbo].[PowodOdrzucenia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Powód] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PowodPrzelozeniaSet'
CREATE TABLE [dbo].[PowodPrzelozeniaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Powód] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RodzajOpakowania'
CREATE TABLE [dbo].[RodzajOpakowania] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rodzaj] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Zawartosc'
CREATE TABLE [dbo].[Zawartosc] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Zawartość] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RodzajZleceniaSet'
CREATE TABLE [dbo].[RodzajZleceniaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rodzaj] varchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId], [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [ZlecenieID] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [PK_Zlecenie]
    PRIMARY KEY CLUSTERED ([ZlecenieID] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatusZlecenie'
ALTER TABLE [dbo].[StatusZlecenie]
ADD CONSTRAINT [PK_StatusZlecenie]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'PowodOdrzucenia'
ALTER TABLE [dbo].[PowodOdrzucenia]
ADD CONSTRAINT [PK_PowodOdrzucenia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PowodPrzelozeniaSet'
ALTER TABLE [dbo].[PowodPrzelozeniaSet]
ADD CONSTRAINT [PK_PowodPrzelozeniaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RodzajOpakowania'
ALTER TABLE [dbo].[RodzajOpakowania]
ADD CONSTRAINT [PK_RodzajOpakowania]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zawartosc'
ALTER TABLE [dbo].[Zawartosc]
ADD CONSTRAINT [PK_Zawartosc]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RodzajZleceniaSet'
ALTER TABLE [dbo].[RodzajZleceniaSet]
ADD CONSTRAINT [PK_RodzajZleceniaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Status] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [FK_ZlecenieStatusZlecenie]
    FOREIGN KEY ([Status])
    REFERENCES [dbo].[StatusZlecenie]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ZlecenieStatusZlecenie'
CREATE INDEX [IX_FK_ZlecenieStatusZlecenie]
ON [dbo].[Zlecenie]
    ([Status]);
GO

-- Creating foreign key on [PowodOdrzuceniaId] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [FK_ZleceniePowodOdrzucenia]
    FOREIGN KEY ([PowodOdrzuceniaId])
    REFERENCES [dbo].[PowodOdrzucenia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ZleceniePowodOdrzucenia'
CREATE INDEX [IX_FK_ZleceniePowodOdrzucenia]
ON [dbo].[Zlecenie]
    ([PowodOdrzuceniaId]);
GO

-- Creating foreign key on [PowodPrzelozeniaId] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [FK_ZleceniePowodPrzelozenia]
    FOREIGN KEY ([PowodPrzelozeniaId])
    REFERENCES [dbo].[PowodPrzelozeniaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ZleceniePowodPrzelozenia'
CREATE INDEX [IX_FK_ZleceniePowodPrzelozenia]
ON [dbo].[Zlecenie]
    ([PowodPrzelozeniaId]);
GO

-- Creating foreign key on [RodzajOpakowaniaId] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [FK_ZlecenieRodzajOpakowania]
    FOREIGN KEY ([RodzajOpakowaniaId])
    REFERENCES [dbo].[RodzajOpakowania]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ZlecenieRodzajOpakowania'
CREATE INDEX [IX_FK_ZlecenieRodzajOpakowania]
ON [dbo].[Zlecenie]
    ([RodzajOpakowaniaId]);
GO

-- Creating foreign key on [ZawartoscId] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [FK_ZlecenieZawartosc]
    FOREIGN KEY ([ZawartoscId])
    REFERENCES [dbo].[Zawartosc]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ZlecenieZawartosc'
CREATE INDEX [IX_FK_ZlecenieZawartosc]
ON [dbo].[Zlecenie]
    ([ZawartoscId]);
GO

-- Creating foreign key on [RodzajZleceniaId] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [FK_ZlecenieRodzajZlecenia]
    FOREIGN KEY ([RodzajZleceniaId])
    REFERENCES [dbo].[RodzajZleceniaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ZlecenieRodzajZlecenia'
CREATE INDEX [IX_FK_ZlecenieRodzajZlecenia]
ON [dbo].[Zlecenie]
    ([RodzajZleceniaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------