CREATE TABLE [dbo].[Accounts] (
    [AccountId] INT           NOT NULL,
    [FirstName] NVARCHAR (20) NOT NULL,
    [LastName]  NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([AccountId] ASC)
);

