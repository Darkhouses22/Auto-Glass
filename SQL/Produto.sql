/*
 Navicat Premium Data Transfer

 Source Server         : SQL Local
 Source Server Type    : SQL Server
 Source Server Version : 16001000
 Source Host           : RAFAEL:1433
 Source Catalog        : desafio
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000
 File Encoding         : 65001

 Date: 26/03/2024 10:53:00
*/


-- ----------------------------
-- Table structure for Produto
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Produto]') AND type IN ('U'))
	DROP TABLE [dbo].[Produto]
GO

CREATE TABLE [dbo].[Produto] (
  [codigo] int  IDENTITY(1,1) NOT NULL,
  [descricao] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [status] bit  NULL,
  [dataFabricacao] datetime  NULL,
  [dataValidade] datetime  NULL,
  [codigoFornecedor] int  NULL,
  [descricaoFornecedor] varchar(255) COLLATE Latin1_General_CI_AS  NULL,
  [cnpjFornecedor] varchar(255) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Produto] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Auto increment value for Produto
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Produto]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table Produto
-- ----------------------------
ALTER TABLE [dbo].[Produto] ADD CONSTRAINT [PK__Produto__40F9A20702203CD8] PRIMARY KEY CLUSTERED ([codigo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

