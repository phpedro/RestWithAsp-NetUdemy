CREATE TABLE `books` (
	`id` varchar(127) PRIMARY KEY NOT NULL,
	`Author` longtext,
	`LaunchDate` datetime(6) NOT NULL,
	`Price` decimal(65,2) NOT NULL,
	`Title` longtext
);