import axios, { AxiosInstance } from 'axios';

const apiClient: AxiosInstance = axios.create({
  baseURL: 'https://localhost:7260/api/', // Replace with your API's base URL
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiClient;