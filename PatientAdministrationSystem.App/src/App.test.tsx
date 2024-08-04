import {render} from '@testing-library/react'
import '@testing-library/jest-dom'

import App from './App';
import PatientSearch from './components/PatientSearch'
import PatientVisitInformation from './components/PatientVisitInformation'

jest.mock('./components/PatientSearch')
jest.mock('./components/PatientVisitInformation')

describe('App', () => {
    test('render app and children', () => {
        render(<App />)
        expect(PatientSearch).toHaveBeenCalled()
        expect(PatientVisitInformation).not.toHaveBeenCalled();
    })
})