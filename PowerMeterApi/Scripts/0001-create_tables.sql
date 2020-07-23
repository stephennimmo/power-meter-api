CREATE TABLE meter
(
    meter_id          NVARCHAR(100) NOT NULL PRIMARY KEY,
    id_authority      NVARCHAR(100) NOT NULL,
    address_line_1    NVARCHAR(250) NOT NULL,
    address_line_2    NVARCHAR(250),
    city              NVARCHAR(250) NOT NULL,
    state             NVARCHAR(2) NOT NULL,
    zip_code          NVARCHAR(10) NOT NULL
)