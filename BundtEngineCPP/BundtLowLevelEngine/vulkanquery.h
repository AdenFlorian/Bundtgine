#pragma once

template <typename T>
std::vector<T> vulkanDeviceQuery(VkPhysicalDevice device, std::function<void(VkPhysicalDevice, uint32_t*, T*)> queryFunction)
{
	uint32_t count = 0;
	queryFunction(device, &count, nullptr);
	std::vector<T> vec(count);
	queryFunction(device, &count, vec.data());
	return vec;
}

template <typename T>
std::vector<T> vulkanDeviceStringQuery(VkPhysicalDevice device, char* str, std::function<void(VkPhysicalDevice, char*, uint32_t*, T*)> queryFunction)
{
	uint32_t count = 0;
	queryFunction(device, str, &count, nullptr);
	std::vector<T> vec(count);
	queryFunction(device, str, &count, vec.data());
	return vec;
}

template <typename T>
std::vector<T> vulkanQuery(std::function<void(uint32_t*, T*)> queryFunction)
{
	uint32_t count = 0;
	queryFunction(&count, nullptr);
	std::vector<T> vec(count);
	queryFunction(&count, vec.data());
	return vec;
}

template <typename T>
std::vector<T> vulkanStringQuery(char* str, std::function<void(char*, uint32_t*, T*)> queryFunction)
{
	uint32_t count = 0;
	queryFunction(str, &count, nullptr);
	std::vector<T> vec(count);
	queryFunction(str, &count, vec.data());
	return vec;
}

template <typename T>
std::vector<T> vulkanInstanceQuery(VkInstance instance, std::function<void(VkInstance, uint32_t*, T*)> queryFunction)
{
	uint32_t count = 0;
	queryFunction(instance, &count, nullptr);
	std::vector<T> vec(count);
	queryFunction(instance, &count, vec.data());
	return vec;
}
