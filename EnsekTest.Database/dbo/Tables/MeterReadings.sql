CREATE TABLE [dbo].[MeterReadings] (
    [MeterReadingId]       INT      NOT NULL,
    [AccountId]            INT      NOT NULL,
    [MeterReadingDateTime] DATETIME NOT NULL,
    [MeterReadingValue]    INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([MeterReadingId] ASC)
);

