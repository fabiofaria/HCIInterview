import api from '../api/apiClient';
import { VisitInformation } from '../models/visitInformation';

class PatientApiService {
    async getPatientVisitInformation(email: string) : Promise<VisitInformation[]> {
        const url = `patients/visit-information?email=${email}`;
        
        const response = await api.get<VisitInformation[]>(url);
        return response.data;
    }
}

export default PatientApiService;