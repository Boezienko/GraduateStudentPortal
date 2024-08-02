CREATE TABLE [dbo].[Person] (
    [PersonId]     INT           NOT NULL,
    [FirstName]    VARCHAR (50)  NOT NULL,
    [LastName]     VARCHAR (50)  NOT NULL,
    [PasswordHash] TEXT          NOT NULL,
    [Email]        VARCHAR (100) NOT NULL,
    [RoleId]       INT           NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC),
    CONSTRAINT [FK_Person_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
);

