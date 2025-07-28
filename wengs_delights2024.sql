-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 28, 2025 at 06:33 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `wengs_delights2024`
--

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`category_id`, `category_name`, `description`) VALUES
(134567, 'Pasta', 'Classic baked macaroni with cheese topping.'),
(145678, 'Pasta', 'Traditional spaghetti with meat sauce.'),
(156789, 'Pasta', 'Creamy carbonara with bacon bits.'),
(167893, 'Pasta', 'Stir-fried noodles with mixed vegetables and meat.'),
(178896, 'Snacks', 'Filipino Food'),
(234567, 'Meals', 'Tender pork leg stewed in soy sauce and spices.'),
(243678, 'Meals', 'Breaded chicken stuffed with ham and cheese.'),
(244567, 'Meals', 'Filipino-style spring rolls filled with vegetables and meat.'),
(267897, 'Meals', 'Description: Crispy fried chicken pieces.'),
(345678, 'Snacks', 'Traditional Filipino dessert made with grated cassava and coconut milk.'),
(356789, 'Snacks', 'Sweet roll filled with macapuno (coconut sport) strips.'),
(367898, 'Snacks', 'Creamy caramel custard dessert.'),
(378899, 'Snacks', 'Soft roll filled with sweetened pili nuts.'),
(888881, 'sweets', 'yummyyy'),
(898989, 'Sweets', 'yummy');

-- --------------------------------------------------------

--
-- Table structure for table `costumer`
--

CREATE TABLE `costumer` (
  `costumer_id` int(11) NOT NULL,
  `lname` varchar(50) NOT NULL,
  `fname` varchar(60) NOT NULL,
  `mname` varchar(50) NOT NULL,
  `address` text NOT NULL,
  `contact_num` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `costumer`
--

INSERT INTO `costumer` (`costumer_id`, `lname`, `fname`, `mname`, `address`, `contact_num`) VALUES
(34535, 'jvgj', 'jhvghgh', 'hfghfg', 'gthg', '08979768678'),
(111111, 'Obusan', 'Isaac', 'Chavez', 'daet', '09186838044'),
(123456, 'g', 'g', 'g', 'g', '555555'),
(143422, 'q', 'q', 'q', 'q', '00'),
(444445, 'aguildsdsd', 'dsds', 'sdsdsdsd', 'sdsds', 'sdsd'),
(555555, 'Aguilar', 'Albert', 'A', 'eewer', '0967756564'),
(678999, 'g', 'g', 'g', 'g', '543524'),
(782222, 'dfsf', 'fsdfsdf', 'sdfsdf', 'sdfdsf', '435345'),
(898989, 'obusan', 'isaac', 'chavez', 'Daet', '09186838044'),
(956678, 'salapan', 'ghgh', 'secret', 'sdfdfsd', '45354'),
(5656556, 'y', 'k', 'y', 'y', '89789');

-- --------------------------------------------------------

--
-- Table structure for table `deliver`
--

CREATE TABLE `deliver` (
  `delivery_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `employee_id` int(11) NOT NULL,
  `lname` varchar(50) NOT NULL,
  `fname` varchar(60) NOT NULL,
  `mname` varchar(50) NOT NULL,
  `position` varchar(30) NOT NULL,
  `address` text NOT NULL,
  `contact_no` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`employee_id`, `lname`, `fname`, `mname`, `position`, `address`, `contact_no`) VALUES
(111111, 'Obusan', 'Rowena', 'Chavez', 'Cook', 'Daet Camarines Norte', '09482419659'),
(111112, 'Obusan', 'Vicente', 'Villare', 'Rider', 'Tigbinan Camarines Norte', 'NA'),
(111113, 'Sena', 'May', 'None', 'Staff', 'Vinzons Camarines NOrte', 'NA'),
(111115, 'Chavez', 'Rodolfo', 'Guinto', 'Staff', 'Vinzons Camarines Norte', 'NA'),
(111116, 'Chavez', 'Coco', 'Cabarle', 'Cook', 'Vinzons Camarines Norte', 'NA'),
(111117, 'Chavez', 'Renee', 'Espinosa', 'Staff', 'Vinzons Camarines Norte', 'NA'),
(222222, 'Obusan', 'Chris', 'Villare', 'Staff', 'Daet', '09556667987'),
(222223, 'Obusan', 'Jely', 'Villare', 'Cook', 'Tigbinan', '09187664561'),
(222224, 'Chavez', 'Ian', 'Cabarle', 'Cook', 'Vinzons', '09777267854'),
(222225, 'Obusan', 'Yvan', 'Villare', 'Staff', 'Tigbinan', '09888564321'),
(222226, 'Obusan', 'Nick', 'Villare', 'Rider', 'Daet', '0911432213'),
(222228, 'Chavez', 'Josh', 'Cabarle', 'Staff', 'Tigbinan', '09887765453'),
(222229, 'Obusan', 'Mackie', 'Villare', 'Cook', 'Tigbinan', '09887665453'),
(333331, 'Chavez', 'Rosa', 'Guinto', 'Staff', 'Vinzons', 'NA'),
(333332, 'Guinto', 'Susan', 'Chavez', 'Staff', 'Vinzons', 'NA'),
(333333, 'Guinto', 'Luz', 'Jalimao', 'Cook', 'Daet', '09888767547'),
(333334, 'Jalimao', 'Emalyn', 'Chavez', 'Cook', 'Vinzons', 'NA'),
(333335, 'Obusan', 'Nik', 'Villare', 'Staff', 'Tigbinan', 'NA'),
(333336, 'Chavez', 'Ernesto', 'Guinto', 'Cook', 'Vinzons', 'NA'),
(333337, 'Obusan', 'Joseph', 'Jalimao', 'Staff', 'Daet', 'NA'),
(333338, 'Chavez', 'Tina', 'Balane', 'Cook', 'Vinzons', 'NA'),
(333339, 'Balane', 'Mark', 'Chavez', 'Rider', 'Vinzons', '09845453245'),
(444441, 'Chavez', 'Rey', 'Abustan', 'Cook', 'Daet', 'NA'),
(444442, 'Chavez', 'Lesther', 'Almacin', 'Cook', 'Daet', 'NA'),
(444443, 'Obusan', 'Mich', 'Jalimao', 'Cook', 'Tigbinan', 'NA'),
(444444, 'Obusan', 'Leah', 'Jalimao', 'Cook', 'Tigbinan', '09876756654'),
(444445, 'Obusan', 'Mikka', 'Jalimao', 'Staff', 'Tigbinan', 'NA');

-- --------------------------------------------------------

--
-- Table structure for table `ingredient`
--

CREATE TABLE `ingredient` (
  `ingredient_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `ingredient_name` varchar(50) NOT NULL,
  `unit` varchar(20) NOT NULL,
  `quantity` int(10) NOT NULL,
  `price` int(10) NOT NULL,
  `description` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ingredient`
--

INSERT INTO `ingredient` (`ingredient_id`, `category_id`, `ingredient_name`, `unit`, `quantity`, `price`, `description`) VALUES
(1, 134567, 'Macaroni pasta', 'grams', 500, 62, 'Macaroni pasta'),
(4, 145678, 'Spaghetti Pasta', 'grams', 500, 75, 'Spaghetti Pasta'),
(7, 156789, 'Spaghetti Pasta', 'grams', 500, 75, 'Carbonara'),
(10, 167893, 'Pancit Noodles', 'grams', 250, 60, 'pancit'),
(13, 234567, 'Pork Leg', 'Kilograms', 1, 170, 'pata'),
(16, 243678, 'Chicken breast fillets', 'pieces', 4, 280, 'fillet'),
(19, 244567, 'Lumpia Wrappers', 'pieces', 20, 129, 'lumpia'),
(22, 267897, 'Chicken Drumsticks', 'pieces', 8, 220, 'fried chicken'),
(25, 345678, 'Grated Cassava', 'kilogram', 1, 160, 'cassava cake'),
(28, 356789, 'Cake Flour', 'kilogram', 1, 120, 'macapuno'),
(31, 367898, 'Egg yolks', 'pieces', 12, 120, 'leche flan'),
(34, 378899, 'Pili nuts ', 'Kilogram', 1, 200, 'pili roll'),
(67, 178896, 'Glutinous Rice Flour', 'Cups', 2, 170, 'Weng\'s Delights  Tikoy'),
(71, 888881, 'flour', 'grams', 500, 90, 'flour');

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `product_id` int(6) NOT NULL,
  `order_date` date NOT NULL,
  `delivery_method` varchar(30) NOT NULL,
  `quantity` int(11) NOT NULL,
  `total_amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`order_id`, `customer_id`, `product_id`, `order_date`, `delivery_method`, `quantity`, `total_amount`) VALUES
(4, 956678, 123450, '2024-07-02', 'Cash on Delivery', 1, 120),
(156678, 123456, 234567, '2024-05-20', 'Cash on Delivery', 1, 400),
(165555, 143422, 890123, '2024-05-20', 'Cash on Delivery', 2, 300),
(456778, 678999, 456789, '2024-05-20', 'Cash on Delivery', 1, 150),
(555566, 5656556, 345678, '2024-05-20', 'Cash on Delivery', 1, 150),
(567888, 898989, 901234, '2024-05-25', 'Cash on Delivery', 3, 390),
(1233213, 782222, 123456, '2024-05-23', 'Cash on Delivery', 2, 800);

-- --------------------------------------------------------

--
-- Table structure for table `prepare`
--

CREATE TABLE `prepare` (
  `prepared_product_id` int(11) NOT NULL,
  `employee_id` varchar(11) DEFAULT NULL,
  `product_id` varchar(11) DEFAULT NULL,
  `date_prepared` date DEFAULT NULL,
  `unit` varchar(20) DEFAULT NULL,
  `quantity` int(10) DEFAULT NULL,
  `date_and_time_of_delivery` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prepare`
--

INSERT INTO `prepare` (`prepared_product_id`, `employee_id`, `product_id`, `date_prepared`, `unit`, `quantity`, `date_and_time_of_delivery`) VALUES
(34234, '444444', '12345', '2024-06-26', '2', 2, 'fg 12 '),
(662667, '787878', '901234', '2024-05-20', 'kilogram', 3, 'May 20,2024  5:38'),
(777111, '111117', '123450', '2024-07-02', '1', 1, 'July 2,2024  8:13 pm');

-- --------------------------------------------------------

--
-- Table structure for table `procure`
--

CREATE TABLE `procure` (
  `procurement_id` int(11) NOT NULL,
  `ingredient_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `date_procured` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `product_id` int(11) NOT NULL,
  `ingredient_ids` varchar(300) NOT NULL,
  `category_id` int(11) NOT NULL,
  `product_name` varchar(100) NOT NULL,
  `price` int(7) NOT NULL,
  `description` varchar(100) NOT NULL,
  `stock` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`product_id`, `ingredient_ids`, `category_id`, `product_name`, `price`, `description`, `stock`) VALUES
(1001, '67', 178896, 'Tikoy', 170, 'Weng\'s Delights Tikoy', 5),
(12345, '28', 356789, 'Macapuno Roll', 150, 'Sweet roll filled with macapuno (coconut sport) strips. Half', 8),
(123450, '31', 367898, 'Leche Flan', 120, 'Creamy caramel custard dessert.', 4),
(123456, '1', 134567, 'Baked Macaroni', 400, 'Classic baked macaroni with cheese topping.', 6),
(156678, '71', 888881, 'Pili Cluster', 40, 'Pili ', 6),
(234501, '34', 378899, 'Pili Roll', 170, 'Soft roll filled with sweetened pili nuts.', 20),
(234567, '4', 145678, 'Spaghetti', 150, 'Traditional spaghetti with meat sauce.', 3),
(345678, '7', 156789, 'Carbonara', 150, 'Creamy carbonara with bacon bits.', 4),
(456789, '10', 167893, 'Pancit Guisado', 150, 'Stir-fried noodles with mixed vegetables and meat', 4),
(567890, '13', 234567, 'Patatim', 750, 'Tender pork leg stewed in soy sauce and spices.', 0),
(678901, '16', 243678, 'Cordon Bleu', 150, 'Breaded chicken stuffed with ham and cheese. Whole', 12),
(789012, '19', 244567, 'Lumpia', 130, 'Filipino-style spring rolls filled with vegetables and meat.', 9),
(890123, '22', 267897, 'Fried Chicken', 200, 'Crispy fried chicken pieces.', 2),
(901234, '25', 345678, 'Cassava Cake', 130, 'Traditional Filipino dessert made with grated cassava and coconut milk.', 9);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `costumer`
--
ALTER TABLE `costumer`
  ADD PRIMARY KEY (`costumer_id`);

--
-- Indexes for table `deliver`
--
ALTER TABLE `deliver`
  ADD PRIMARY KEY (`delivery_id`),
  ADD UNIQUE KEY `employee_id` (`employee_id`),
  ADD UNIQUE KEY `order_id` (`order_id`),
  ADD UNIQUE KEY `customer_id` (`customer_id`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`employee_id`);

--
-- Indexes for table `ingredient`
--
ALTER TABLE `ingredient`
  ADD PRIMARY KEY (`ingredient_id`),
  ADD UNIQUE KEY `category_id` (`category_id`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`order_id`),
  ADD UNIQUE KEY `customer_id` (`customer_id`),
  ADD UNIQUE KEY `product_id` (`product_id`);

--
-- Indexes for table `prepare`
--
ALTER TABLE `prepare`
  ADD PRIMARY KEY (`prepared_product_id`),
  ADD UNIQUE KEY `employee_id` (`employee_id`),
  ADD UNIQUE KEY `product_id` (`product_id`);

--
-- Indexes for table `procure`
--
ALTER TABLE `procure`
  ADD PRIMARY KEY (`procurement_id`),
  ADD UNIQUE KEY `ingredient_id` (`ingredient_id`),
  ADD UNIQUE KEY `employee_id` (`employee_id`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_id`),
  ADD UNIQUE KEY `category_id` (`category_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
