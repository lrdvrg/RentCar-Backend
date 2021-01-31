
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/31/2021 17:17:18
-- Generated from EDMX file: C:\Users\isaid\source\repos\RentCar\RentCar\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RentCar];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Inspectio__Clien__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inspection] DROP CONSTRAINT [FK__Inspectio__Clien__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__Inspectio__Emplo__4AB81AF0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inspection] DROP CONSTRAINT [FK__Inspectio__Emplo__4AB81AF0];
GO
IF OBJECT_ID(N'[dbo].[FK__Inspectio__Vehic__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inspection] DROP CONSTRAINT [FK__Inspectio__Vehic__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK__Model__BrandId__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Model] DROP CONSTRAINT [FK__Model__BrandId__3A81B327];
GO
IF OBJECT_ID(N'[dbo].[FK__RentAndRe__Clien__4E88ABD4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentAndRefund] DROP CONSTRAINT [FK__RentAndRe__Clien__4E88ABD4];
GO
IF OBJECT_ID(N'[dbo].[FK__RentAndRe__Emplo__4F7CD00D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentAndRefund] DROP CONSTRAINT [FK__RentAndRe__Emplo__4F7CD00D];
GO
IF OBJECT_ID(N'[dbo].[FK__RentAndRe__Vehic__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentAndRefund] DROP CONSTRAINT [FK__RentAndRe__Vehic__4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__Vehicle__BrandId__403A8C7D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT [FK__Vehicle__BrandId__403A8C7D];
GO
IF OBJECT_ID(N'[dbo].[FK__Vehicle__FuelTyp__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT [FK__Vehicle__FuelTyp__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__Vehicle__ModelId__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT [FK__Vehicle__ModelId__412EB0B6];
GO
IF OBJECT_ID(N'[dbo].[FK__Vehicle__Vehicle__3F466844]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT [FK__Vehicle__Vehicle__3F466844];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brand];
GO
IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[FuelType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuelType];
GO
IF OBJECT_ID(N'[dbo].[Inspection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inspection];
GO
IF OBJECT_ID(N'[dbo].[Model]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Model];
GO
IF OBJECT_ID(N'[dbo].[RentAndRefund]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RentAndRefund];
GO
IF OBJECT_ID(N'[dbo].[Vehicle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicle];
GO
IF OBJECT_ID(N'[dbo].[VehicleType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Brand'
CREATE TABLE [dbo].[Brand] (
    [BrandId] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(200)  NULL,
    [Status] varchar(20)  NULL
);
GO

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [ClientId] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [DocumentNo] varchar(100)  NULL,
    [CreditCard] varchar(100)  NULL,
    [CreditLimit] int  NULL,
    [ClientType] varchar(100)  NULL,
    [Status] varchar(20)  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [DocumentNo] varchar(100)  NULL,
    [BatchLabor] varchar(16)  NULL,
    [CommissionPercentage] varchar(100)  NULL,
    [AdmissionDate] varchar(120)  NULL,
    [Status] varchar(20)  NULL
);
GO

-- Creating table 'FuelType'
CREATE TABLE [dbo].[FuelType] (
    [FuelTypeId] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(200)  NULL,
    [Status] varchar(20)  NULL
);
GO

-- Creating table 'Inspection'
CREATE TABLE [dbo].[Inspection] (
    [InspectionId] int IDENTITY(1,1) NOT NULL,
    [Fuel] varchar(6)  NULL,
    [HaveGrated] varchar(6)  NULL,
    [HaveReplacementTyre] varchar(6)  NULL,
    [HaveJack] varchar(6)  NULL,
    [HaveWindowCrack] varchar(6)  NULL,
    [FLTyreStatus] varchar(12)  NULL,
    [FRTyreStatus] varchar(12)  NULL,
    [RLTyreStatus] varchar(12)  NULL,
    [RRTyreStatus] varchar(12)  NULL,
    [Comment] varchar(200)  NULL,
    [Date] datetime  NULL,
    [Status] varchar(20)  NULL,
    [VehicleId] int  NULL,
    [ClientId] int  NULL,
    [EmployeeId] int  NULL
);
GO

-- Creating table 'Model'
CREATE TABLE [dbo].[Model] (
    [ModelId] int IDENTITY(1,1) NOT NULL,
    [BrandId] int  NULL,
    [Description] varchar(200)  NULL,
    [Status] varchar(20)  NULL
);
GO

-- Creating table 'RentAndRefund'
CREATE TABLE [dbo].[RentAndRefund] (
    [RentAndRefundId] int IDENTITY(1,1) NOT NULL,
    [RentDate] datetime  NULL,
    [RefundDate] datetime  NULL,
    [AmountPerDay] int  NULL,
    [AmountOfDays] int  NULL,
    [Comment] varchar(200)  NULL,
    [Status] varchar(20)  NULL,
    [VehicleId] int  NULL,
    [ClientId] int  NULL,
    [EmployeeId] int  NULL
);
GO

-- Creating table 'Vehicle'
CREATE TABLE [dbo].[Vehicle] (
    [VehicleId] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(200)  NULL,
    [Status] varchar(20)  NULL,
    [ChasisNo] varchar(30)  NULL,
    [MotorNo] varchar(30)  NULL,
    [PlateNo] varchar(30)  NULL,
    [VehicleTypeId] int  NULL,
    [BrandId] int  NULL,
    [ModelId] int  NULL,
    [FuelTypeId] int  NULL
);
GO

-- Creating table 'VehicleType'
CREATE TABLE [dbo].[VehicleType] (
    [VehicleTypeId] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(200)  NULL,
    [Status] varchar(20)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BrandId] in table 'Brand'
ALTER TABLE [dbo].[Brand]
ADD CONSTRAINT [PK_Brand]
    PRIMARY KEY CLUSTERED ([BrandId] ASC);
GO

-- Creating primary key on [ClientId] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([ClientId] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [FuelTypeId] in table 'FuelType'
ALTER TABLE [dbo].[FuelType]
ADD CONSTRAINT [PK_FuelType]
    PRIMARY KEY CLUSTERED ([FuelTypeId] ASC);
GO

-- Creating primary key on [InspectionId] in table 'Inspection'
ALTER TABLE [dbo].[Inspection]
ADD CONSTRAINT [PK_Inspection]
    PRIMARY KEY CLUSTERED ([InspectionId] ASC);
GO

-- Creating primary key on [ModelId] in table 'Model'
ALTER TABLE [dbo].[Model]
ADD CONSTRAINT [PK_Model]
    PRIMARY KEY CLUSTERED ([ModelId] ASC);
GO

-- Creating primary key on [RentAndRefundId] in table 'RentAndRefund'
ALTER TABLE [dbo].[RentAndRefund]
ADD CONSTRAINT [PK_RentAndRefund]
    PRIMARY KEY CLUSTERED ([RentAndRefundId] ASC);
GO

-- Creating primary key on [VehicleId] in table 'Vehicle'
ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [PK_Vehicle]
    PRIMARY KEY CLUSTERED ([VehicleId] ASC);
GO

-- Creating primary key on [VehicleTypeId] in table 'VehicleType'
ALTER TABLE [dbo].[VehicleType]
ADD CONSTRAINT [PK_VehicleType]
    PRIMARY KEY CLUSTERED ([VehicleTypeId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BrandId] in table 'Model'
ALTER TABLE [dbo].[Model]
ADD CONSTRAINT [FK__Model__BrandId__3A81B327]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[Brand]
        ([BrandId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Model__BrandId__3A81B327'
CREATE INDEX [IX_FK__Model__BrandId__3A81B327]
ON [dbo].[Model]
    ([BrandId]);
GO

-- Creating foreign key on [BrandId] in table 'Vehicle'
ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [FK__Vehicle__BrandId__403A8C7D]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[Brand]
        ([BrandId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Vehicle__BrandId__403A8C7D'
CREATE INDEX [IX_FK__Vehicle__BrandId__403A8C7D]
ON [dbo].[Vehicle]
    ([BrandId]);
GO

-- Creating foreign key on [ClientId] in table 'Inspection'
ALTER TABLE [dbo].[Inspection]
ADD CONSTRAINT [FK__Inspectio__Clien__49C3F6B7]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Client]
        ([ClientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Inspectio__Clien__49C3F6B7'
CREATE INDEX [IX_FK__Inspectio__Clien__49C3F6B7]
ON [dbo].[Inspection]
    ([ClientId]);
GO

-- Creating foreign key on [ClientId] in table 'RentAndRefund'
ALTER TABLE [dbo].[RentAndRefund]
ADD CONSTRAINT [FK__RentAndRe__Clien__4E88ABD4]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Client]
        ([ClientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RentAndRe__Clien__4E88ABD4'
CREATE INDEX [IX_FK__RentAndRe__Clien__4E88ABD4]
ON [dbo].[RentAndRefund]
    ([ClientId]);
GO

-- Creating foreign key on [EmployeeId] in table 'Inspection'
ALTER TABLE [dbo].[Inspection]
ADD CONSTRAINT [FK__Inspectio__Emplo__4AB81AF0]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employee]
        ([EmployeeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Inspectio__Emplo__4AB81AF0'
CREATE INDEX [IX_FK__Inspectio__Emplo__4AB81AF0]
ON [dbo].[Inspection]
    ([EmployeeId]);
GO

-- Creating foreign key on [EmployeeId] in table 'RentAndRefund'
ALTER TABLE [dbo].[RentAndRefund]
ADD CONSTRAINT [FK__RentAndRe__Emplo__4F7CD00D]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employee]
        ([EmployeeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RentAndRe__Emplo__4F7CD00D'
CREATE INDEX [IX_FK__RentAndRe__Emplo__4F7CD00D]
ON [dbo].[RentAndRefund]
    ([EmployeeId]);
GO

-- Creating foreign key on [FuelTypeId] in table 'Vehicle'
ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [FK__Vehicle__FuelTyp__4222D4EF]
    FOREIGN KEY ([FuelTypeId])
    REFERENCES [dbo].[FuelType]
        ([FuelTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Vehicle__FuelTyp__4222D4EF'
CREATE INDEX [IX_FK__Vehicle__FuelTyp__4222D4EF]
ON [dbo].[Vehicle]
    ([FuelTypeId]);
GO

-- Creating foreign key on [VehicleId] in table 'Inspection'
ALTER TABLE [dbo].[Inspection]
ADD CONSTRAINT [FK__Inspectio__Vehic__48CFD27E]
    FOREIGN KEY ([VehicleId])
    REFERENCES [dbo].[Vehicle]
        ([VehicleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Inspectio__Vehic__48CFD27E'
CREATE INDEX [IX_FK__Inspectio__Vehic__48CFD27E]
ON [dbo].[Inspection]
    ([VehicleId]);
GO

-- Creating foreign key on [ModelId] in table 'Vehicle'
ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [FK__Vehicle__ModelId__412EB0B6]
    FOREIGN KEY ([ModelId])
    REFERENCES [dbo].[Model]
        ([ModelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Vehicle__ModelId__412EB0B6'
CREATE INDEX [IX_FK__Vehicle__ModelId__412EB0B6]
ON [dbo].[Vehicle]
    ([ModelId]);
GO

-- Creating foreign key on [VehicleId] in table 'RentAndRefund'
ALTER TABLE [dbo].[RentAndRefund]
ADD CONSTRAINT [FK__RentAndRe__Vehic__4D94879B]
    FOREIGN KEY ([VehicleId])
    REFERENCES [dbo].[Vehicle]
        ([VehicleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RentAndRe__Vehic__4D94879B'
CREATE INDEX [IX_FK__RentAndRe__Vehic__4D94879B]
ON [dbo].[RentAndRefund]
    ([VehicleId]);
GO

-- Creating foreign key on [VehicleTypeId] in table 'Vehicle'
ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [FK__Vehicle__Vehicle__3F466844]
    FOREIGN KEY ([VehicleTypeId])
    REFERENCES [dbo].[VehicleType]
        ([VehicleTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Vehicle__Vehicle__3F466844'
CREATE INDEX [IX_FK__Vehicle__Vehicle__3F466844]
ON [dbo].[Vehicle]
    ([VehicleTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------