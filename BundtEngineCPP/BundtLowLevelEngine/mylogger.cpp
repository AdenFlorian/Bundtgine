#pragma once

#include <iostream>
#include <string>

void LogInfo(const std::string message)
{
	std::cout << "info: " << message << std::endl;
}