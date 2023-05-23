-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 22, 2023 at 05:31 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


-- Database: `inventory_db`
--
CREATE DATABASE IF NOT EXISTS `inventory_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `inventory_db`;
--
-- Database: `item_db`
--
CREATE DATABASE IF NOT EXISTS `item_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `item_db`;

-- --------------------------------------------------------

--
-- Table structure for table `tblitems`
--

CREATE TABLE `tblitems` (
  `ID` int(11) NOT NULL,
  `ITEMNAME` varchar(255) NOT NULL,
  `ITEMDESCRIPTION` varchar(255) NOT NULL,
  `QTY` int(255) NOT NULL,
  `PRICE` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tblitems`
--

INSERT INTO `tblitems` (`ID`, `ITEMNAME`, `ITEMDESCRIPTION`, `QTY`, `PRICE`) VALUES
(1, 'RYZEN PROCESSOR', 'NEW CPU', 2, 3000),
(2, 'test0', 'fds0', 2, 3),
(4, 'razer keybaortd', 'new keyboard', 34, 20000),
(5, 'a4tech process', 'new processor', 2, 2000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblitems`
--
ALTER TABLE `tblitems`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblitems`
--
ALTER TABLE `tblitems`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- Database: `phpmyadmin`
--
CREATE DATABASE IF NOT EXISTS `phpmyadmin` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin;
USE `phpmyadmin`;

-- --------------------------------------------------------
