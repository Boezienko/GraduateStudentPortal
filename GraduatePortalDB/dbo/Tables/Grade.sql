CREATE TABLE [dbo].[Grade] (
    [PersonId] INT         NOT NULL,
    [ClassId]  INT         NOT NULL,
    [Grade]    VARCHAR (2) NOT NULL,
    CONSTRAINT [FK_Grade_Class] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Class] ([ClassId]),
    CONSTRAINT [FK_Grade_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);



