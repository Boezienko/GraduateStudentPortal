CREATE TABLE [dbo].[Grade] (
    [PersonId]     INT NOT NULL,
    [AssignmentId] INT NOT NULL,
    [Grade]        INT NOT NULL,
    CONSTRAINT [FK_Grade_Assignment] FOREIGN KEY ([AssignmentId]) REFERENCES [dbo].[Assignment] ([AssignmentId]),
    CONSTRAINT [FK_Grade_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);

