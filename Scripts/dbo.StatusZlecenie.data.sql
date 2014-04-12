SET IDENTITY_INSERT [dbo].[StatusZlecenie] ON
INSERT INTO [dbo].[StatusZlecenie] ([Id], [Nazwa]) VALUES (1, N'Zrealizowane')
INSERT INTO [dbo].[StatusZlecenie] ([Id], [Nazwa]) VALUES (2, N'W trakcie realizacji przez kuriera')
SET IDENTITY_INSERT [dbo].[StatusZlecenie] OFF
