CREATE TABLE [dbo].[Class] (
    [ClassId]   INT           IDENTITY (1, 1) NOT NULL,
    [ClassName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED ([ClassId] ASC)
);

