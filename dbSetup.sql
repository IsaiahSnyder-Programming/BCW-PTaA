CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
--
--
CREATE TABLE IF NOT EXISTS trips (
  creatorId varchar(255) NOT NULL,
  id INT AUTO_INCREMENT primary key,
  name TEXT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';
--
--
DROP TABLE trips;
--
--
INSERT INTO
  trips (name, `creatorId`)
VALUES
  ('Dystopia', '621fe5d6dbe50cea2b338f0c');
--
  --
SELECT
  *
FROM
  trips;
--
  --
SELECT
  t.*,
  a.*
FROM
  trips t
  JOIN accounts a
WHERE
  a.id = t.creatorId;