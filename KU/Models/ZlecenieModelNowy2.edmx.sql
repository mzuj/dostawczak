
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/19/2014 11:20:54
-- Generated from EDMX file: C:\Users\TomekI\documents\visual studio 2013\Projects\KU\KU\Models\ZlecenieModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_ZlecenieRodzajOpakowania]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zlecenie] DROP CONSTRAINT [FK_ZlecenieRodzajOpakowania];
GO
IF OBJECT_ID(N'[dbo].[FK_ZlecenieOknoWyjazdu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zlecenie] DROP CONSTRAINT [FK_ZlecenieOknoWyjazdu];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[Zlecenie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zlecenie];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[RodzajOpakowania]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RodzajOpakowania];
GO
IF OBJECT_ID(N'[dbo].[OknoWyjazduSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OknoWyjazduSet];
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
    [RodzajZleceniaId] int  NULL,
    [OknoWyjazduId] int  NOT NULL,
    [Ilosc_nieudanych_prob_realizacji] int  NOT NULL,
    [Data_nasepnej_proby] datetime  NOT NULL,
    [KanalySprzedazyId] int  NOT NULL
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

-- Creating table 'RodzajOpakowania'
CREATE TABLE [dbo].[RodzajOpakowania] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rodzaj] nvarchar(max)  NOT NULL,
    [Rozmiar] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OknoWyjazduSet'
CREATE TABLE [dbo].[OknoWyjazduSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rozpoczęcie] datetime  NOT NULL,
    [Zakończenie] datetime  NOT NULL
);
GO

-- Creating table 'KanalySprzedazySet'
CREATE TABLE [dbo].[KanalySprzedazySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(max)  NOT NULL
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

-- Creating primary key on [Id] in table 'RodzajOpakowania'
ALTER TABLE [dbo].[RodzajOpakowania]
ADD CONSTRAINT [PK_RodzajOpakowania]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OknoWyjazduSet'
ALTER TABLE [dbo].[OknoWyjazduSet]
ADD CONSTRAINT [PK_OknoWyjazduSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KanalySprzedazySet'
ALTER TABLE [dbo].[KanalySprzedazySet]
ADD CONSTRAINT [PK_KanalySprzedazySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [OknoWyjazduId] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [FK_ZlecenieOknoWyjazdu]
    FOREIGN KEY ([OknoWyjazduId])
    REFERENCES [dbo].[OknoWyjazduSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ZlecenieOknoWyjazdu'
CREATE INDEX [IX_FK_ZlecenieOknoWyjazdu]
ON [dbo].[Zlecenie]
    ([OknoWyjazduId]);
GO

-- Creating foreign key on [KanalySprzedazyId] in table 'Zlecenie'
ALTER TABLE [dbo].[Zlecenie]
ADD CONSTRAINT [FK_ZlecenieKanalySprzedazy]
    FOREIGN KEY ([KanalySprzedazyId])
    REFERENCES [dbo].[KanalySprzedazySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ZlecenieKanalySprzedazy'
CREATE INDEX [IX_FK_ZlecenieKanalySprzedazy]
ON [dbo].[Zlecenie]
    ([KanalySprzedazyId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------